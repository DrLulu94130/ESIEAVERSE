using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class DBManager : MonoBehaviour
{
    [SerializeField] Text txtValue, txtMaxScore;


    public void GenerateNumber()
    {
        int number = GenerateRandomNumber();
        txtValue.text = number.ToString();
        StartCoroutine(InsertIntoDataBase(number));
        
    }

    int GenerateRandomNumber()
    {
        int rand = Random.Range(0, 1000001);
        return rand;
    }

    IEnumerator InsertIntoDataBase(int num)
    {
        // Change url to your own
        string url = "https://pstesieaverse.alwaysdata.net/insertscore.php";
        WWWForm form = new WWWForm();
        form.AddField("score", num);
        using(UnityWebRequest www = UnityWebRequest.Post(url, form)) 
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print("error");
            }
            else
            {
                print(www.downloadHandler.text);
                txtMaxScore.text = "MAX SCORE: " + www.downloadHandler.text;
            }
        }
    }
}
