using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    public Camera Tab;
    public bool Trigger;
    public Tableau Board;
    [SerializeField] GameObject CameraHolder;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        Board = GetComponent<Tableau>();
    }

    // Update is called once per frame
    void Update()
    {
        Tab.enabled = Trigger;
        bool tab = Board.Trigger;
        if (tab)
        {
            if (PV.IsMine)
            {
                Tab.enabled = true;
                    CameraHolder.SetActive(false);
            }
        }
        if(!tab)
        {
            if (PV.IsMine)
            {
                CameraHolder.SetActive(true);
                Tab.enabled = false;
            }
        }
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
