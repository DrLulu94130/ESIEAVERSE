using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] GameObject Model;
    [SerializeField] Animator anim;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    public PlayAudio audio;
    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    bool pause = false;
    bool emote_wheel = false;
    Rigidbody rb;

    PhotonView PV;

    float H_input;
    float V_input;

    private void Awake()
    {
        SoundManager.Instance.StopSound();
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }



    private void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
        if (PV.IsMine)
        {
            Destroy(Model);
        }
    }

    void Update()
    {
        if (!PV.IsMine)
            return;
        if(Pause.isOn)
        {
            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            pause = !pause;
        }
        if(pause == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            emote_wheel = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            emote_wheel = false;
        }

        anim.SetFloat("H_input", H_input);
        anim.SetFloat("V_input", V_input);
        Look();
        Move();
        Jump();
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }



    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Math.Clamp(verticalLookRotation, -70f, 70f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }



    void Move()
    {

        if (Pause.isOn)
        {
            Vector3 moveDirP = new Vector3(0, 0, 0);
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDirP * ((Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
        }
        else
        {
            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * ((Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

            H_input = Input.GetAxisRaw("Horizontal");
            V_input = Input.GetAxisRaw("Vertical");
           

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Walking", false);
                anim.SetBool("Running", true);
                audio.IsSprinting = true;
                audio.IsWalking = false;  
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Running", false);
                anim.SetBool("Walking", false);
                anim.SetBool("Jumping", true);
            }
            else
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", false);
                anim.SetBool("Walking", true);
                audio.IsSprinting = false;

                if (moveAmount != new Vector3(0, 0, 0))
                {
                    audio.IsWalking = true;
                }

            }
        }
    }



    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }


    public void SetGroudedState(bool _grounded)
    {
        grounded = _grounded;
    }


    private void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

}
