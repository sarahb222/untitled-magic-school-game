using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Classroom : MonoBehaviour
{
    public GameObject scheduleMaster;
    private GameObject UI;
    private ClockScript clock;
    public Schedule schedule;
    private GameObject classNotification;
    private Text changeText;
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private Vector2 spawnLocation;

    void Start()
    {
        scheduleMaster = GameObject.Find("ScheduleMaster");
        UI = GameObject.Find("UI");
        clock = UI.GetComponent<ClockScript>();
        classNotification = UI.transform.Find("Canvas").transform.Find("ClassNotification").gameObject;
        changeText = classNotification.transform.Find("Class Text").gameObject.GetComponent<Text>();
    }
    
    void Update()
    {
        if(schedule.mw.A == "")
        {
            schedule = scheduleMaster.GetComponent<ScheduleManager>().playerSchedule;
        }
    }

    private void OnTriggerEnter2D(Collider2D door)
    {
        if (door.gameObject.CompareTag("Player"))
        {
            if (clock.dayoftheWeek == "Monday" || clock.dayoftheWeek == "Wednesday")
            {
                CheckIfClass(schedule.mw);
            } else if (clock.dayoftheWeek == "Tuesday" || clock.dayoftheWeek == "Thursday")
            {
                CheckIfClass(schedule.tth);
            }
            else if (clock.dayoftheWeek == "Friday") {
                CheckIfClass(schedule.f);
            }
            else {
                classNotification.SetActive(true);
                changeText.text = "There's no class on " + clock.dayoftheWeek + "s!";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D door)
    {
        classNotification.SetActive(false);
    }

        private void CheckIfClass(Schedule.Classes whichDay)
    {   //Determine which time slot to look at
        int checker;
        if (clock.hours < 7)
        {
            checker = 1;
        } else if (clock.hours < 9)
        {
            checker = 2;
        } else if (clock.hours < 12)
        {
            checker = 3;
        } else if (clock.hours < 14)
        {
            checker = 4;
        } else if (clock.hours < 16)
        {
            checker = 5;
        }
        else
        {
            checker = 6;
        }

        //Look at any time slots past the current time
        if (whichDay.A == this.name && checker <= 1)
        {
            classNotification.SetActive(true);
            changeText.text = "You have this class at 7:00 today!";
        } else if (whichDay.A == this.name && (clock.hours == 7 || (clock.hours == 8 && clock.minutes < 30)))
        {
            GatewayManager.Instance.SetSpawnPosition(spawnLocation);
            SceneManager.LoadScene(sceneName);
        } else if (whichDay.B == this.name && checker <= 2)
        {
            classNotification.SetActive(true);
            changeText.text = "You have this class at 9:00 today!";
        }else if (whichDay.B == this.name && (clock.hours == 9 || (clock.hours == 10 && clock.minutes < 30)))
        {
            GatewayManager.Instance.SetSpawnPosition(spawnLocation);
            SceneManager.LoadScene(sceneName);
        } else if (whichDay.C == this.name && checker <= 3)
        {
            classNotification.SetActive(true);
            changeText.text = "You have this class at 12:00 today!";
        }else if (whichDay.C == this.name && (clock.hours == 12 || (clock.hours == 13 && clock.minutes < 30)))
        {
            GatewayManager.Instance.SetSpawnPosition(spawnLocation);
            SceneManager.LoadScene(sceneName);
        } else if (whichDay.D == this.name && checker <= 4)
        {
            classNotification.SetActive(true);
            changeText.text = "You have this class at 14:00 today!";
        }else if (whichDay.D == this.name && (clock.hours == 14 || (clock.hours == 15 && clock.minutes < 30)))
        {
            GatewayManager.Instance.SetSpawnPosition(spawnLocation);
            SceneManager.LoadScene(sceneName);
        } else if (whichDay.E == this.name && checker <= 5)
        {
            classNotification.SetActive(true);
            changeText.text = "You have this class at 16:00 today!";
        }else if (whichDay.E == this.name && (clock.hours == 16 || (clock.hours == 17 && clock.minutes < 30)))
        {
            GatewayManager.Instance.SetSpawnPosition(spawnLocation);
            SceneManager.LoadScene(sceneName);
        }
        else if(checker == 6)
        {
            classNotification.SetActive(true);
            changeText.text = "There are no more classes today!";
        }
        else
        {
            //Technically they could have had the class today, but earlier on in the day
            classNotification.SetActive(true);
            changeText.text = "You don't have this class today!";
        }
    }
    
}
