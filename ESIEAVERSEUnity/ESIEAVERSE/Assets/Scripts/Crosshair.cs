using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public static bool isOn = true;

    public GameObject CrosshairUI;

    // Start is called before the first frame update
    void Start()
    {
        CrosshairUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if( (Pause.isOn) || (EmoteWheel.isOn) || (Tableau.isOn) || (Bibliotheque.isOn) )
        {
            CrosshairUI.SetActive(false);
            isOn = false;
        }
        else
        {
            CrosshairUI.SetActive(true);
            isOn = true;
        }
    }
}
