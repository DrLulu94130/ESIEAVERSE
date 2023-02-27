using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;

public class MyRecorder : MonoBehaviour
{
    public Recorder myRecorder;

    void Start(){
        myRecorder= GetComponent<Recorder>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.V)){
            myRecorder.TransmitEnabled = true;
        }
        else{
            myRecorder.TransmitEnabled = false;
        }
    }
}
