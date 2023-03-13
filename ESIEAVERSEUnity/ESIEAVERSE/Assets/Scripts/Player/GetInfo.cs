using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class GetInfo : MonoBehaviour
{
    public Timer ThisTimer;
    public string message;
    public int MyID;
    public string MyRole;

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
            MyID = PlayerPrefs.GetInt("ID");
            MyRole = PlayerPrefs.GetString("role");
            message = "";
            foreach (var item in PhotonNetwork.PlayerList)
            {
                message += "name : ";
                message += item.NickName;
                message += " | ID : ";
                message += MyID;
                message += " | role : ";
                message += MyRole;
                message = "";
            }
        }
    }
}