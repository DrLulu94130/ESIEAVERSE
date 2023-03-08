using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = System.Random;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private PhotonView PV;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnPoint();
        {
            PV = GetComponent<PhotonView>();
            if(PlayerCustom.nj == 0)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "0"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 1)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "1"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 2)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "2"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 3)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "3"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 4)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "4"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 5)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "5"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 6)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "6"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 7)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "7"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 8)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "8"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 9)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "9"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 10)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "10"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 11)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "11"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 12)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "12"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 13)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "13"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 14)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "14"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 15)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "15"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 16)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "16"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 17)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "17"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 18)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "18"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == -1)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "10"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 19)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "19"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 20)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "20"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 21)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "21"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 22)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "22"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 23)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "23"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 24)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "24"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 25)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "25"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 26)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "26"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 27)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "27"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 28)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "28"), spawnpoint.position, spawnpoint.rotation);
            }
            if (PlayerCustom.nj == 29)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "29"), spawnpoint.position, spawnpoint.rotation);
            }
        }
        
    }
}
