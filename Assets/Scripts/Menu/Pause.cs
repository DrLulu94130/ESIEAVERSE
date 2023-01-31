using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviourPunCallbacks
{
    public static bool isOn = false;
    public void Leave()
    {
        LeaveRoom();
        OnLeftRoom();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);

        base.OnLeftRoom();
    }
    public void ToMainMenu()
    {
        Destroy(RoomManager.Instance);
        PhotonNetwork.LeaveRoom();
        StartCoroutine(LoadAsynchronously(0));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        MenuManager.Instance.OpenMenu("loading");

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}

