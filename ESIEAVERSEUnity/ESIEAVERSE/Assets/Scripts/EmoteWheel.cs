using System.Collections;
using System.Collections.Generic;
using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class EmoteWheel : MonoBehaviour
{
    public static bool EmoteWheelIsOn = false;

    public GameObject EmoteWheelUI;

    [SerializeField] Animator anim;

    void Start()
    {
        ToggleEmoteWheel(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EmoteWheelIsOn = true;
            ToggleEmoteWheel(EmoteWheelIsOn);
            if(Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            return;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            EmoteWheelIsOn = false;
            ToggleEmoteWheel(EmoteWheelIsOn);
        }
    }


    public void ToggleEmoteWheel(bool EmoteWheelIsOn)
    {

        EmoteWheelUI.SetActive(EmoteWheelIsOn);
    }


    public void Top()
    {
        Debug.Log("Waving");
        anim.SetBool("Top", true);
    }
    public void TopR()
    {
        Debug.Log("Salute");
        anim.SetBool("TopR", true);
    }
    public void TopL()
    {
        Debug.Log("Shake Hands");
        anim.SetBool("TopTopL", true);
    }

    public void Bottom()
    {
        Debug.Log("Searching Pockets");
        anim.SetBool("Bottom", true);
    }
    public void BottomR()
    {
        Debug.Log("Laughing");
        anim.SetBool("BottomR", true);
    }
    public void BottomL()
    {
        Debug.Log("Being Cocky");
        anim.SetBool("BottomL", true);
    }
}
