using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;



public class VocalUi : MonoBehaviour
{
    [SerializeField] GameObject Touche;
    public static bool display = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Touche.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Touche.SetActive(false);
        }
    }
}
