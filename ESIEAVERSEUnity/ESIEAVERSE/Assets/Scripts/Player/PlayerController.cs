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
    Rigidbody rb;

    PhotonView PV;

    float H_input;
    float V_input;

    bool emotewheel = false;

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
            emotewheel = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            emotewheel = false;
        }

        H_input = Input.GetAxis("Horizontal");
        V_input = Input.GetAxis("Vertical");

        anim.SetFloat("H_input", H_input, 0.1f, smoothTime);
        anim.SetFloat("V_input", V_input, 0.1f, smoothTime);

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            audio.IsSprinting = true;
        }
        else
        {
            audio.IsSprinting = false;
        }
        if (Pause.isOn)
        {
            Vector3 moveDirP = new Vector3(0, 0, 0);
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDirP * ((Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
        }
        else
        {
            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * ((Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {

                anim.SetBool("Walking", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", true);
                audio.IsSprinting = true;
                audio.IsWalking = false;
            }
            else if (Input.GetKey(KeyCode.Space))
            {

                anim.SetBool("Walking", false);
                anim.SetBool("Running", false);
                anim.SetBool("Jumping", true);
            }
            else if (Input.GetKey(KeyCode.F))
            {

                anim.SetTrigger("Interact");
            }
            else
            {

                anim.SetBool("Running", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Walking", true);
                audio.IsSprinting = false;
                audio.IsWalking = true;
            }

            /*if (moveAmount != new Vector3(0, 0, 0))
            {

            }
            else
            {
                
            }*/
        }
    }

    void Jump()
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
