using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class GetInfo : MonoBehaviour
{
    public Timer ThisTimer;
    private string message;
    public List<string> messages = new List<string>();

    private void Start()
    {
        ThisTimer = GetComponent<Timer>();
    }

    void Update()
    {
        if (ThisTimer.TimerRunOut)
        {
            ThisTimer.timeRemaining = 5;
            ThisTimer.timerIsRunning = true;
            messages = new List<string>();
            foreach (var item in PhotonNetwork.PlayerList)
            {
                message += "name : ";
                message += item.NickName;
                message += " | ID : ";
                message += PlayerPrefs.GetInt("ID");
                message += " | role : ";
                message += PlayerPrefs.GetString("role");
                messages.Add(message);
                message = "";
            }
        }
    }
}