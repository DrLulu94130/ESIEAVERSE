using System.Collections;
using System.Collections.Generic;
using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Pointeur : MonoBehaviour
{

    public static bool isOn = true;
    public GameObject PointeurUI;

    // Start is called before the first frame update
    void Start()
    {
        PointeurUI.SetActive(true);
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {

        if( (Pause.isOn) || (Tableau.isOn) || (EmoteWheel.isOn))
        {

            if( (Pause.isOn) || (EmoteWheel.isOn))
            {
                PointeurUI.SetActive(false);
                isOn = false;
            }
            else
            {
                PointeurUI.SetActive(true);
                isOn = true;
            }
        }
        
    }
}


