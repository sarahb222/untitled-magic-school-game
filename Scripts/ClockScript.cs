using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClockScript : MonoBehaviour
{
    private float inGameMinute = 1; // How many seconds is a real time minute
    private static GameObject instance;

    private String gameTime;
    public int years = 1;
    public String season = "Spring";
    public int days = 1;
    public int hours = 0;
    public int minutes = 0;
    public String dayoftheWeek = "Sunday";
    public Text time;
    public Image nighttime;

    IEnumerator Start()
    {
        //Every time the save file loads, it is always 6:00 am
        hours = 6;
        
        //Clock persists throughout the scenes
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this.gameObject;
            while (true)
            {
                yield return new WaitForSecondsRealtime(inGameMinute);

                //Only increase the time if the player is outside
                if (SceneManager.GetActiveScene().name == "Schoolgrounds") {
                    //In Game Minute Passed. Do Something
                    minutes = minutes + 1;

                    UpdateTime();

                    GetTime();
                }
                
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    //Get the time to display it to the screen
    public String GetTime()
    {

        gameTime = string.Format("{0:00}:{1:00}", hours, minutes);
        return gameTime;
    }

    void FixedUpdate()
    {
        //Update the display to show the current time
        time.text = dayoftheWeek + " " + days + " " + season + " " + years + " " + GetTime();

        Scene scene = SceneManager.GetActiveScene();

        //If it is between 18:00 and 6:00 then it is dark outside! Only changes the outside to be dark, not the inside.
        if ((hours >= 18 || hours < 6)  && (scene.name == "Schoolgrounds"))
        {
            nighttime.enabled = true; ;
        }
        else
        {
            nighttime.enabled = false;
        }
        
    }

    //Updates the time
    public void UpdateTime()
    {
        //Minutes can never be 60 or more, reset them to 0 and add 1 hour
        if (minutes == 60)
        {
            hours = hours + 1;
            minutes = 0;
        }

        //Hours can never be 24 or more, reset them to 0 and add 1 day
        if (hours == 24)
        {
            hours = 0;
            days = days + 1;
        }

        //Days can never be 22 or more, reset them to 1 and add 1 to the season
        if (days == 22)
        {
            days = 1;
            if (season == "Spring")
            {
                season = "Summer";
            } else if (season == "Summer")
            {
                season = "Fall";
            } else if (season == "Fall")
            {
                season = "Winter";
            }
            else
            {
                //Increase the year
                season = "Spring";
                years = years + 1;
            }
        }
        
    }
    
}
