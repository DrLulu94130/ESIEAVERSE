using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCustom : MonoBehaviour
{
    [SerializeField] GameObject[] Player;
    [SerializeField] GameObject Admin;
    int s;
    public static int nj = -1;
    [SerializeField] Animator anim;
    [SerializeField] TMP_InputField usernameInput;
    // Start is called before the first frame update PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
    void Start()
    {
        if(PlayerPrefs.HasKey("username"))
        {
            usernameInput.text = PlayerPrefs.GetString("username");
            PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        }
        else
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
            OnUsernameInputValueChanged();
        }

        if (nj == -1)
        {
            s = 10;
            Player[s].SetActive(true);
        }
        else
        {
            s = nj;
            Player[nj].SetActive(true);
        }
    }

    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
    }

    public void Droite()
    {
        if (s == 19)
        {
            Admin.SetActive(false);
        }
        else
        {
            Player[s].SetActive(false);
        }
        s += 1;
        if(s == 20)
        {
            s = 0;
        }
        if(s == 19)
        {
            Admin.SetActive(true);
        }
        else
        {
            Player[s].SetActive(true);
        }
    }
    public void Gauche()
    {

        if (s == 19)
        {
            Admin.SetActive(false);
        }
        else
        {
            Player[s].SetActive(false);
        }
        s -= 1;
        if(s == -1)
        {
            s = 19;
        }
        if (s == 19)
        {
            Admin.SetActive(true);
        }
        else
        {
            Player[s].SetActive(true);
        }
    }
    public void V()
    {
        nj = s;
        anim.SetTrigger("v");

    }
}
