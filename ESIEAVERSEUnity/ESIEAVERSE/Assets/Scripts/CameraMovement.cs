using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        bool PressF = Input.GetKey(KeyCode.F);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation , -90f , 90f );

        transform.localRotation = Quaternion.Euler(xRotation , 0f , 0f);
        if ( xRotation >= 30 && PressF)
        {
            transform.position = new Vector3(playerBody.position.x , playerBody.position.y + (xRotation)/10 , playerBody.position.z);
        }
        else
        {
            transform.position = new Vector3(playerBody.position.x , playerBody.position.y , playerBody.position.z);
        }
        playerBody.Rotate( Vector3.up * mouseX);

    }
}
