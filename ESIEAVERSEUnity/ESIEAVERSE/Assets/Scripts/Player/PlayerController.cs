using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject cameraHolder;
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
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }



    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Math.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }



    void Idle()
    {
        audio.IsWalking = false;
        audio.IsSprinting = false;
        anim.SetFloat("Vitesse", 0);

    }

    void Walking()
    {
        audio.IsWalking = true;
        audio.IsSprinting = false;
        anim.SetFloat("Vitesse", 1, 0.20f, smoothTime);

    }

    void Running()
    {
        audio.IsWalking = false;
        audio.IsSprinting = true;
        anim.SetFloat("Vitesse", 2);
    }

    void Sprinting()
    {
        audio.IsWalking = false;
        audio.IsSprinting = true;
        anim.SetFloat("Vitesse", 3, 0.20f, smoothTime);
    }

    void Bacward()
    {
        audio.IsWalking = true;
        audio.IsSprinting = false;
        anim.SetFloat("Vitesse", -1, 0.20f, smoothTime);
    }

    void Jumping()
    {
        audio.IsWalking = false;
        audio.IsSprinting = false;
        //Blend tree spécial
    }

    void Sides()
    {
        audio.IsWalking = true;
        audio.IsSprinting = false;
        //Blend tree spécial
    }

    void Interact()
    {

        //à faire
    }


    void Move_anim()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sprinting();
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Bacward();
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //blend tree dédié
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //blend tree dédié
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //blend tree dédié
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Walking();
            
        }
        /*if (Input.GetKeyDown(KeyCode.RightClick))
        {
            Interact();
        }*/
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
                //J'ai déplacé les anim en dehors et j'ai expliqué à Alexandre pourquoi
                Move_anim();

            }
            else
            {
                Idle();
                audio.IsWalking = false;
                audio.IsSprinting = false;
                
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
