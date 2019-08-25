using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClockScript : MonoBehaviour
{
    private float inGameMinute = 1; // How many seconds is a real time minute
    private static GameObject instance;

    private System.TimeSpan gameTime;
    public int years = 1;
    public int seasons = 1;
    public int days = 1;
    public int hours = 0;
    public int minutes = 0;
    public Text time;
    public Image nighttime;

    IEnumerator Start()
    {
        hours = 6;
        

        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this.gameObject;
            while (true)
            {
                yield return new WaitForSecondsRealtime(inGameMinute);

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

    public System.TimeSpan GetTime()
    {

        gameTime = new System.TimeSpan((int)hours, (int)minutes, 0);
        return gameTime;
    }

    void FixedUpdate()
    {
        time.text = "Year: " + years + " Season: " + seasons + " Day: " + days + " " + GetTime().ToString();

        Scene scene = SceneManager.GetActiveScene();

        if ((hours >= 18 || hours < 6)  && (scene.name == "Schoolgrounds"))
        {
            nighttime.enabled = true; ;
        }
        else
        {
            nighttime.enabled = false;
        }
        
    }

    public void UpdateTime()
    {
        if (minutes == 60)
        {
            hours = hours + 1;
            minutes = 0;
        }
        if (hours == 24)
        {
            hours = 0;
            days = days + 1;
        }
        if (days == 22)
        {
            days = 1;
            seasons = seasons + 1;
        }
        if (seasons == 5)
        {
            seasons = 1;
            years = years + 1;
        }
    }
    
}
