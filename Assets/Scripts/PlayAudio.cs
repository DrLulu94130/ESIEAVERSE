using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource Walk , Sprint;
    public bool IsSprinting,IsWalking;


    void Update()
    {
        if ( IsWalking )
        {
            Walk.enabled = true;
            if ( IsSprinting )
            {
                Walk.enabled = false;
                Sprint.enabled = true;
            }
        }
        else
        {
            Walk.enabled = false;
            Sprint.enabled = false;
        }
    }
}
