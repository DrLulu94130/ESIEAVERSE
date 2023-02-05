using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool TimerRunOut;
    public float timeRemaining;
    public bool timerIsRunning = false;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                TimerRunOut = false;
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                TimerRunOut = true;
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}