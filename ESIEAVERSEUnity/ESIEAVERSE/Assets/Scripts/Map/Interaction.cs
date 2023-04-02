using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Timer Coutdown;
    public DoorInteraction Door;
    public LightSwitch Switch;
    public Tableau Board;
    public Bibliotheque Library;
    public bool Triggered;
    public bool Selected;
    public bool AsBeenSelected;

    void Start()
    {
        Coutdown = GetComponent<Timer>();
        Door = GetComponent<DoorInteraction>();
        Switch = GetComponent<LightSwitch>();
        Board = GetComponent<Tableau>();
        Library = GetComponent<Bibliotheque>();
    }

    void Update()
    {
        if ( Coutdown ) //Reset of the Outline Script
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

        //Selection of scripts

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

        if ( Board )
        {
            if ( Triggered )
            {
                Board.Trigger = true;
            }
            else
            {
                Board.Trigger = false;
            }
        }

        if( Library  )
        {
            if (Triggered)
            {
                Bibliotheque.isOn = true;
            }
            else
            {
                Bibliotheque.isOn = false;
            }
        }

    }
}
