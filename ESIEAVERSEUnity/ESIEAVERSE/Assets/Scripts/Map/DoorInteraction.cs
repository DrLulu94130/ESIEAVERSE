using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Quaternion localRot1;
    public Quaternion localRot2;
    public bool Open;
    public bool isChair;
    public bool lastPosition;

    public AudioClip AudioOpen;
    public AudioClip AudioClose;
    public AudioSource audioSource;


    Transform tf;

    void Start()
    {
        tf = GetComponent<Transform>();
    }

    void Update()// Change Rotation, Playing Audio and activate timer
    {
        if ( Open )
        {
            tf.rotation = localRot2;
        }
        else
        {
            tf.rotation = localRot1;
        }
        if ( lastPosition != Open )
        {
            lastPosition = Open;
            if ( Open )
            {
                audioSource.PlayOneShot(AudioOpen);
            }
            else
            {
                audioSource.PlayOneShot(AudioClose);
            }
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
