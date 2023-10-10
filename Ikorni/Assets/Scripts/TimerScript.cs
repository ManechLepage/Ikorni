using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 3f;
    public bool timerIsRunning = false;
    public TMP_Text DashTimer;
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
                timeRemaining -= Time.deltaTime;
                DashTimer.SetText("Dash: " + timeRemaining.ToString());
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                DashTimer.SetText("Dash: Ready");
            }
        }
    }
}