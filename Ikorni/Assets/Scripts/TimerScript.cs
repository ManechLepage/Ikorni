using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 0f;
    public bool timerIsRunning = false;
    public TMP_Text DashTimer;
    public bool canDash = true;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DashTimer.SetText("Dash: " + ((Mathf.Round(10*timeRemaining))/10).ToString());
                canDash = false;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                DashTimer.SetText("Dash: Ready");
                canDash = true;
                
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            if(canDash == true){
                timeRemaining = 3f;
                timerIsRunning = true;
            }
            
                }
    }
}