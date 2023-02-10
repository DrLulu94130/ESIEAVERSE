using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using baseRandom = System.Random;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;
    public static bool isco = false;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject startGameButton;
    [SerializeField] private AudioClip _clip;
    [SerializeField] AudioClip[] clips;
    public int Nscene = 1;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isco == false)
        {
            UnityEngine.Debug.Log("Connecting to master");
            PhotonNetwork.ConnectUsingSettings();
            SoundManager.Instance.PlaySound(_clip);
            isco = true;
        }
    }

    public override void OnConnectedToMaster()
    {
        UnityEngine.Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        if (PlayerPrefs.HasKey("username"))
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        }
        else
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
        }
        UnityEngine.Debug.Log("Joined Lobby");
    }

    // Update is called once per frame
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        SoundManager.Instance.PlaySound(clips[0]);
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    void CheckMaster()
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        MenuManager.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
        SoundManager.Instance.PlaySound(clips[3]);
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform tranf in roomListContent)
        {
            Destroy(tranf.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    public void ChoseMairieDivry()
    {
        PhotonNetwork.LoadLevel(2);
    }
    public void ChoseMarieCurie()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void StartGame()
    {
        if (Nscene == 1)
        {
            PhotonNetwork.LoadLevel(1);
        }
        if (Nscene == 2)
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        PhotonNetwork.IsMessageQueueRunning = false;

        PhotonNetwork.LoadLevel(sceneIndex);
        var operation = PhotonNetwork.LevelLoadingProgress;

        MenuManager.Instance.OpenMenu("loading");

        while (operation < 1f)
        {
        
            yield return null;
        }
    }
}
