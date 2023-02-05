using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    [SerializeField] Text txtValue;
    [SerializeField] Text ErrorField;
    [SerializeField] InputField Username , Password;
    [SerializeField] string url;
    
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
                ErrorField.text = "ID : " + www.downloadHandler.text;
                if(response == "0") 
                {
                    ErrorField.text = "Invalid username or password";
                } 
                else 
                {
                    ErrorField.text = "ID : " + www.downloadHandler.text;
                }
                txtValue.text = "Name : " + Username.text + " | " + "Password : " + Password.text ;
            }
        }
    }
}
