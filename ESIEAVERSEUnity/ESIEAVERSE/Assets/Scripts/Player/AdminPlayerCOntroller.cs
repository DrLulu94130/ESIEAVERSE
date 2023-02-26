using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class AdminPlayerController : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] GameObject Model;
    [SerializeField] Animator anim;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    bool pause = false;
    Rigidbody rb;

    PhotonView PV;

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
        Look();
        Move();
        Jump();
        Down();
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
            if (moveAmount != new Vector3(0, 0, 0))
            {

                if(Input.GetKeyDown(KeyCode.W))
                {
                    anim.SetBool("walk", true);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    anim.SetBool("backward", true);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    anim.SetBool("walkL", true);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    anim.SetBool("walkR", true);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("jump", true);
                }


            }
            else
            {
                anim.SetBool("run", false);
                anim.SetBool("walk", false);
                anim.SetBool("backward", false);
                anim.SetBool("walkL", false);
                anim.SetBool("walkR", false);
                anim.SetBool("jump", false);
                
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
        Vector3 moveDirP = new Vector3(0, 0, 0);
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDirP * ((Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }
    void Down()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            rb.AddForce(-transform.up * jumpForce);
        }
        Vector3 moveDirP = new Vector3(0, 0, 0);
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDirP * ((Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

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
