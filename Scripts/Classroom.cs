using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classroom : MonoBehaviour
{
    public GameObject scheduleMaster;
    private GameObject clockMaster;
    private ClockScript clock;
    public Schedule schedule;

    void Start()
    {
        scheduleMaster = GameObject.Find("ScheduleMaster");
        clockMaster = GameObject.Find("UI");
        clock = clockMaster.GetComponent<ClockScript>();
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
        if(clock.dayoftheWeek == "Monday" || clock.dayoftheWeek == "Wednesday")
        {
            char when = CheckIfClass(schedule.mw);
        }else if(clock.dayoftheWeek == "Tuesday" || clock.dayoftheWeek == "Thursday")
        {

        }else if(clock.dayoftheWeek == "Friday"){

        }else{
            Debug.Log("There's no class on " + clock.dayoftheWeek + "s!");
        }

        Debug.Log(clock.minutes);
    }

    private char CheckIfClass(Schedule.Classes whichDay)
    {
        if (whichDay.A == this.name)
        {
            Debug.Log("You have this class at 7:10 today!");
            return 'A';
        } else if (whichDay.B == this.name)
        {
            Debug.Log("You have this class at 9:10 today!");
            return 'B';
        } else if (whichDay.C == this.name)
        {
            Debug.Log("You have this class at 12:10 today!");
            return 'C';
        } else if (whichDay.D == this.name)
        {
            Debug.Log("You have this class at 14:10 today!");
            return 'D';
        } else if (whichDay.E == this.name)
        {
            Debug.Log("You have this class at 16:10 today!");
            return 'E';
        }else
        {
            Debug.Log("You don't have this class today!");
            return 'F';
        }
    }
}
