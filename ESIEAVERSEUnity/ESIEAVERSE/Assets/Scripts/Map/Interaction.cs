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
    //[SerializeField] GameObject u;

    // Start is called before the first frame update
    void Start()
    {
        Coutdown = GetComponent<Timer>();
        Door = GetComponent<DoorInteraction>();
        Switch = GetComponent<LightSwitch>();
        Board = GetComponent<Tableau>();
        Library = GetComponent<Bibliotheque>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Coutdown )
        {
            if (Selected && !AsBeenSelected)
            {
                wait();
                AsBeenSelected = true;
                Coutdown.timeRemaining = .5f;
                Coutdown.timerIsRunning = true;
                //u.SetActive(true);

            }

            if ( Coutdown.TimerRunOut )
            {
                //u.SetActive(false);
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }
}
