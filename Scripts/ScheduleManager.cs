using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    public Schedule playerSchedule;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the all skills
        playerSchedule = Initialize(playerSchedule);
    }

    //Initialize schedule
    private Schedule Initialize(Schedule schedule)
    {
        schedule = new Schedule();
        schedule.mw = new Schedule.Classes();
        schedule.mw.A = "Fire";
        schedule.mw.B = "Water";
        schedule.mw.C = "Air";
        schedule.mw.D = "Earth";
        schedule.mw.E = "Animal Care";
        schedule.tth = new Schedule.Classes();
        schedule.tth.A = "Potions";
        schedule.tth.B = "Fire";
        schedule.tth.C = "Animal Care";
        schedule.tth.D = "Water";
        schedule.tth.E = "Earth";
        schedule.f = new Schedule.Classes();
        schedule.f.A = "Potions";
        schedule.f.B = "Air";
        schedule.f.C = "Potions";
        schedule.f.D = "Air";
        schedule.f.E = "Break";
        return schedule;
    }
}
