using System.Collections;
using System.Collections.Generic;
using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class EmoteWheel : MonoBehaviour
{
    public static bool isOn = false;

    public GameObject EmoteWheelUI;

    public Animator anim;

    void Start()
    {
        ToggleEmoteWheel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOn = true;
            ToggleEmoteWheel();
            
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isOn = false;
            ToggleEmoteWheel();
        }
    }


    public void ToggleEmoteWheel()
    {

        EmoteWheelUI.SetActive(isOn);

        if (isOn)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    public void Top()
    {
        Debug.Log("Waving");
        anim.SetBool("Top", true);
        Reset();
    }
    public void TopR()
    {
        Debug.Log("Salute");
        anim.SetBool("TopR", true);
        Reset();
    }
    public void TopL()
    {
        Debug.Log("Shake Hands");
        anim.SetBool("TopL", true);
        Reset();
    }

    public void Bottom()
    {
        Debug.Log("Searching Pockets");
        anim.SetBool("Bottom", true);
        Reset();
    }
    public void BottomR()
    {
        Debug.Log("Laughing");
        anim.SetBool("BottomR", true);
        Reset();
    }
    public void BottomL()
    {
        Debug.Log("Being Cocky");
        anim.SetBool("BottomL", true);
        Reset();
    }

    public IEnumerator Reset()
    {   
        yield return new WaitForSeconds(3.2f);

        anim.SetBool("Top", false);
        anim.SetBool("TopR", false);
        anim.SetBool("TopL", false);
        anim.SetBool("Bottom", false);
        anim.SetBool("BottomR", false);
        anim.SetBool("BottomL", false);

        anim.SetBool("Idling", true);
    }
}
