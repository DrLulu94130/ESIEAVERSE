using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteWheel : MonoBehaviour
{
    public static bool EmoteWheelIsOn = false;

    public GameObject EmoteWheelUI;

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
    }
    public void TopR()
    {
        Debug.Log("Salute");
    }
    public void TopL()
    {
        Debug.Log("Shake Hands");
    }

    public void Bottom()
    {
        Debug.Log("Searching Pockets");
    }
    public void BottomR()
    {
        Debug.Log("Laughing");
    }
    public void BottomL()
    {
        Debug.Log("Being Cocky");
    }
}
