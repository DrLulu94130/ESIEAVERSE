using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ActivateModel : MonoBehaviour
{
    PhotonView PV;
    [SerializeField] GameObject[] Player;
    // Start is called before the first frame update

    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PlayerCustom.nj != -1)
        {
            if (PV.IsMine)
            {
                Player[PlayerCustom.nj].SetActive(true);
                UnityEngine.Debug.Log("marche");
            }
        }
        else
        { 
            int s = Random.Range(0, 18);
            Player[s].SetActive(true);
       }
    }
}
