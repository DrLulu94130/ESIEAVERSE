using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Timer Coutdown;
    public DoorInteraction Door;
    public LightSwitch Switch;
    public Outline Selection;
    public bool Triggered;
    public bool Selected;
    public bool AsBeenSelected;

    // Start is called before the first frame update
    void Start()
    {
        Coutdown = GetComponent<Timer>();
        Door = GetComponent<DoorInteraction>();
        Switch = GetComponent<LightSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Coutdown )
        {
            if (Selected && !AsBeenSelected)
            {
                AsBeenSelected = true;
                Coutdown.timeRemaining = .5f;
                Coutdown.timerIsRunning = true;
            }

            if ( Coutdown.TimerRunOut )
            {
                AsBeenSelected = false;
                Selected = false;
            }
        }


        if (Door)
        {
            if ( Triggered )
            {
                Door.Open = true;
            }
            else
            {
                Door.Open = false;
            }
        }

        if (Switch)
        {
            if ( Triggered )
            {
                Switch.isOn = true;
            }
            else
            {
                Switch.isOn = false;
            }
        }
    }
}
