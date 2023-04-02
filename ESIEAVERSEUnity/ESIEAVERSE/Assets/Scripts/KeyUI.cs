using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;



public class KeyUI : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.H))
        {
            UnityEngine.Debug.Log("F");
            display = !display;
        }
        if (display)
        {
            Touche.SetActive(true);
        }
        if (!display)
        {
            Touche.SetActive(false);
        }
    }
}
