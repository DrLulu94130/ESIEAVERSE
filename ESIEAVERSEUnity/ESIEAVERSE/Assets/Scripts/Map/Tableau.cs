using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    public Camera Tab;
    public bool Trigger;
    public Tableau Board;
    [SerializeField] GameObject Camera;
    public PhotonView PV;
    public static bool o;
    public static bool done;
    public static bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        Board = GetComponent<Tableau>();
    }

    // Update is called once per frame
    void Update()
    {
        o = Trigger;
        bool tab = Trigger;
        if (tab)
        {
            isOn = true;
            if (PV.IsMine)
            {
                UnityEngine.Debug.Log("CAM");
                Camera.SetActive(true);
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isOn = false;
                Camera.SetActive(false);
                done = false;
            }
        }
       /* if(!tab)
        {
            if (PV.IsMine)
            {
                Camera.SetActive(false);
                done = false;
            }
        }*/
        if ( !GetComponent<Timer>().TimerRunOut )
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
        }
    }
}
