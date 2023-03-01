using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun.UtilityScripts;

public class LoginScript : MonoBehaviour
{
    [SerializeField] Text txtValue;
    [SerializeField] Text ErrorField;
    [SerializeField] InputField Username , Password;
    [SerializeField] string url;
    public static int ID;
    public static string role;
    
    public void StartLogin()
    {
        StartCoroutine(LoginToServer());
    }

    IEnumerator LoginToServer()
    {
        WWWForm form = new WWWForm();
        form.AddField( "Username" , Username.text );
        form.AddField( "Password" , Password.text );
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                txtValue.text = "non" ;
            }
            else
            {
                string response = www.downloadHandler.text;
                if(response == "Informations de login incorrectes") 
                {
                    ErrorField.text = response;
                } 
                else 
                {

                    string[] splitResponse = response.Split(',');
                    ID = int.Parse(splitResponse[0]);
                    role = splitResponse[1];
                    ErrorField.text = "ID : " + ID + "\nRole : " + role;
                    PlayerPrefs.SetInt("ID",ID);
                    PlayerPrefs.SetString("role",role);
                    
                }
                txtValue.text = ""; //"Name : " + Username.text + " | " + "Password : " + Password.text ;
            }
        }
    }
}