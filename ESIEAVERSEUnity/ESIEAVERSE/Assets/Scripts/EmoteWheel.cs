/*This code serves as a way to first of all display at the right time the emote wheel and to apply to chosen animation to the player. It detect interaction with the emote wheel and order the inGame Animator to change the player animation*/

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
    public GameObject Playerez;

    public Animator anim;

    void Start()
    {
        Playerez = GameObject.Find("10(Clone)");
        anim = Playerez.transform.GetChild(0).gameObject.GetComponent<Animator>();
        ToggleEmoteWheel();
    }

    // Update is called once per frame
    void Update()
    {
        Playerez = GameObject.Find("10(Clone)");
        anim = Playerez.transform.GetChild(0).gameObject.GetComponent<Animator>();
        
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
        anim.SetTrigger("Top");
    }
    public void TopR()
    {
        Debug.Log("Salute");
        anim.SetTrigger("TopR");
    }
    public void TopL()
    {
        Debug.Log("Shake Hands");
        anim.SetTrigger("TopL");
    }

    public void Bottom()
    {
        Debug.Log("Searching Pockets");
        anim.SetTrigger("Bottom");
    }
    public void BottomR()
    {
        Debug.Log("Laughing");
        anim.SetTrigger("BottomR");
    }
    public void BottomL()
    {
        Debug.Log("Being Cocky");
        anim.SetTrigger("BottomL");
    }

}
