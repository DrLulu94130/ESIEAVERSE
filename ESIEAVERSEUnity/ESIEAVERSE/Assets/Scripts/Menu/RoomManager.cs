using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
        if (scene.buildIndex == 2)
        {
            if (PlayerCustom.nj == 0)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "0"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 1)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "1"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 2)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "2"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 3)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "3"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 4)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "4"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 5)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "5"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 6)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "6"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 7)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "7"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 8)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "8"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 9)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "9"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 10)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "10"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 11)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "11"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 12)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "12"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 13)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "13"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 14)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "14"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 15)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "15"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 16)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "16"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 17)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "17"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 18)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "18"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == -1)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "10"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 19)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "19"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 20)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "20"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 21)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "21"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 22)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "22"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 23)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "23"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 24)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "24"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 25)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "25"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 26)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "26"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 27)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "27"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 28)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "28"), Vector3.zero, Quaternion.identity);
            }
            if (PlayerCustom.nj == 29)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "29"), Vector3.zero, Quaternion.identity);
            }
        }
    }
}
