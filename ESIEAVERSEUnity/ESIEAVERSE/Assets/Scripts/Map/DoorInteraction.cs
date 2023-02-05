using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Quaternion localRot1;
    public Quaternion localRot2;
    public bool Open;

    Transform tf;

    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Open )
        {
            tf.rotation = localRot2;
        }
        else
        {
            tf.rotation = localRot1;
        }

        if ( !GetComponent<Timer>().TimerRunOut )
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
        }
    }
}
