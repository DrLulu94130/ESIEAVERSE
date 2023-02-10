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

}
