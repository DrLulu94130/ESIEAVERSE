using System;
using System.Threading;
using Photon.Pun;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun.UtilityScripts;


public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] public GameObject cameraHolder;
    [SerializeField] GameObject Model;
    [SerializeField] Animator anim;
    [SerializeField] float mouseSensitivity, sprintSpeed, sneakSpeed, walkSpeed, jumpForce, smoothTime;
    [SerializeField] GameObject CameraHolder;

    public string message;
    public float role;
    float verticalLookRotation;
    float speed = 0;
    float H_input;
    float V_input;

    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    bool go = false;
    bool pause = false;
    bool grounded;
    bool tab;
    bool tableau = true;
    bool chat = false;

    PhotonView PV;
    Rigidbody rb;



    private void Awake()
    {
        SoundManager.Instance.StopSound();
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        anim.SetLayerWeight(anim.GetLayerIndex("UpperBody Layer"), 0);

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
        tab = Tableau.o;
        if (!PV.IsMine)
            return;

        if ((tab) && (Tableau.done))
        {
            //UnityEngine.Debug.Log("test");
            if (PV.IsMine)
            {
                CameraHolder.SetActive(false);
            }
        }
        if (!(tab))
        {

            //UnityEngine.Debug.Log("test2");
            if (PV.IsMine)
            {
                CameraHolder.SetActive(true);
            }
        }
        
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            if (PV.IsMine)
            {
                CameraHolder.SetActive(true);
                return;
            }
        }*/
        
        if ((Pause.isOn) || (Tableau.isOn) || (EmoteWheel.isOn) || (Bibliotheque.isOn))
        {   
            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            return;
        }
        else if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Pause.isOn = false;
            Tableau.isOn = false;
            EmoteWheel.isOn = false;
            Bibliotheque.isOn = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) && (Pause.isOn))
        {
            pause = !pause;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            chat = !chat;
        }
        if((pause == true) || (chat == true))
        {
            Vector3 moveDirP = new Vector3(0, 0, 0);
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDirP * 0, ref smoothMoveVelocity, smoothTime);
            return;
        }

        /*if (Input.GetKey(KeyCode.T))
        {
            if (PV.IsMine)
            {
                if (!tableau)
                {
                    CameraHolder.SetActive(false);
                    tableau = true;
                }
                else
                {
                    if (tableau)
                    {
                        CameraHolder.SetActive(true);
                        tableau = false;
                    }

                }
            }
                    
        }*/

        H_input = Input.GetAxis("Horizontal");
        V_input = Input.GetAxis("Vertical");

        anim.SetFloat("H_input", H_input, 0.1f, smoothTime);
        anim.SetFloat("V_input", V_input, 0.1f, smoothTime);

        Look();
        Move();
        Jump();

        StartCoroutine(UpperBody()); 
    }



    /*IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        CameraHolder.SetActive(false);
    }*/



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
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDirP * 0, ref smoothMoveVelocity, smoothTime);
        }
        else
        {
            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
                go = true;
            }
            if (Input.GetKey(KeyCode.C))
            {
                speed = sneakSpeed;
                go = true;
            }

            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (go ? speed : walkSpeed), ref smoothMoveVelocity, smoothTime);
            go = false;

            if (moveAmount != new Vector3(0, 0, 0))
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("Walking", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Running", true);
                    anim.SetBool("Sneaking", false);

                    anim.SetBool("Idling", false);

                    if (Input.GetKey(KeyCode.C))
                    {
                        anim.SetBool("Walking", false);
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", false);
                        anim.SetBool("Sneaking", true);

                        anim.SetBool("Idling", false);

                        if (Input.GetKeyDown(KeyCode.Space) && grounded)
                        {
                            anim.SetBool("Running", false);
                            anim.SetBool("Jumping", true);
                            anim.SetBool("Walking", false);
                            anim.SetBool("Sneaking", false);

                            anim.SetBool("Idling", false);
                        }
                        else
                        {
                            anim.SetBool("Jumping", false);
                        }
                    }
                }
                else if (Input.GetKey(KeyCode.C))
                {
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Sneaking", true);

                    anim.SetBool("Idling", false);

                    if (Input.GetKeyDown(KeyCode.Space) && grounded)
                    {
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", true);
                        anim.SetBool("Walking", false);
                        anim.SetBool("Sneaking", false);

                        anim.SetBool("Idling", false);
                    }
                    else
                    {
                        anim.SetBool("Jumping", false);
                    }

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        anim.SetBool("Walking", false);
                        anim.SetBool("Jumping", false);
                        anim.SetBool("Running", true);
                        anim.SetBool("Sneaking", false);

                        anim.SetBool("Idling", false);

                        if (Input.GetKeyDown(KeyCode.Space) && grounded)
                        {
                            anim.SetBool("Running", false);
                            anim.SetBool("Jumping", true);
                            anim.SetBool("Walking", false);
                            anim.SetBool("Sneaking", false);

                            anim.SetBool("Idling", false);
                        }
                        else
                        {
                            anim.SetBool("Jumping", false);
                        }
                    }
                }
                else
                {
                    anim.SetBool("Walking", true);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Sneaking", false);

                    anim.SetBool("Idling", false);

                    if (Input.GetKeyDown(KeyCode.Space) && grounded)
                    {
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", true);
                        anim.SetBool("Walking", false);
                        anim.SetBool("Sneaking", false);

                        anim.SetBool("Idling", false);
                    }
                    else
                    {
                        anim.SetBool("Jumping", false);
                    }
                }
            }
            else
            {

                if (Input.GetKey(KeyCode.C))
                {
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Sneaking", true);

                    anim.SetBool("Idling", false);

                    if (Input.GetKeyDown(KeyCode.Space) && grounded)
                    {
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", true);
                        anim.SetBool("Walking", false);
                        anim.SetBool("Sneaking", false);

                        anim.SetBool("Idling", false);
                    }
                    else
                    {
                        anim.SetBool("Jumping", false);
                    }
                }
                else
                {
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("Jumping", false);
                    anim.SetBool("Sneaking", false);

                    anim.SetBool("Idling", true);

                    if (Input.GetKeyDown(KeyCode.Space) && grounded)
                    {
                        anim.SetBool("Running", false);
                        anim.SetBool("Jumping", true);
                        anim.SetBool("Walking", false);
                        anim.SetBool("Sneaking", false);

                        anim.SetBool("Idling", false);
                    }
                    else
                    {
                        anim.SetBool("Jumping", false);
                    }         
                }          
            }
        }
    }



    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }
    }



    private IEnumerator UpperBody()
    {   

        if (Input.GetKey(KeyCode.F))
        {
            anim.SetLayerWeight(anim.GetLayerIndex("UpperBody Layer"), 0.5f);
            anim.SetBool("OpeningDoor", true);

            yield return new WaitForSeconds(1.2f);
            anim.SetLayerWeight(anim.GetLayerIndex("UpperBody Layer"), 0);
        }
        else if (Input.GetKey(KeyCode.V))
        {
            anim.SetLayerWeight(anim.GetLayerIndex("UpperBody Layer"), 0.5f);
            anim.SetBool("Talking", true);

            yield return new WaitForSeconds(2);
            anim.SetLayerWeight(anim.GetLayerIndex("UpperBody Layer"), 0);
        }
        else
        {
            anim.SetBool("Talking", false);
            anim.SetBool("OpeningDoor", false);
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
