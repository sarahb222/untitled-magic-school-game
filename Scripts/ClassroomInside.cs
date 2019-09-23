using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClassroomInside : MonoBehaviour
{
    private GameObject UI;
    private ClockScript clock;
    public Schedule schedule;
    private GameObject classNotification;
    private Text changeText;
    private GameObject player;
    private Skills playerSkills;
    private int increaseByMax = 12;
    private int increaseByLevel = 12;
    [SerializeField]
    private string className;
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private Vector2 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //Pause movement
        player.GetComponent<Player>().paused = true;

        //Find the UI and clock etc
        UI = GameObject.Find("UI");
        clock = UI.GetComponent<ClockScript>();
        classNotification = UI.transform.Find("Canvas").transform.Find("ClassNotification").gameObject;
        changeText = classNotification.transform.Find("Class Text").gameObject.GetComponent<Text>();
        playerSkills = GameObject.Find("SkillMaster").GetComponent<SkillMaster>().playerSkills.playerSkills;

        //Check which class it is
        if(className == "Water")
        {
            CheckWhichToIncrease(playerSkills.water);
        }

        //Increase the time because class is over!
        IncreaseTime();

        //Class is over, time to go back outside
        LeaveClassroom();
    }

    void CheckWhichToIncrease(Skills.SkillStats thisClass)
    {
        //If it is the first year, max class level is 5
        if(clock.years == 1)
        {
            if(thisClass.max < 5)
            {
                IncreaseStats(thisClass, 5, true);
            }
            else if(thisClass.max == 5)
            {
                IncreaseStats(thisClass, 5, false);
            }
            
        }
    }

    void IncreaseStats(Skills.SkillStats thisClass, int max, bool lessThan)
    {
        //If the max skill level isn't yet equal to the max for that year, increase only the max skill level
        if (lessThan)
        {
            thisClass.maxEXP += increaseByMax;
            if (thisClass.maxEXP >= 100)
            {
                thisClass.maxEXP -= 100;
                thisClass.max += 1;
                if (thisClass.max == max)
                {
                    thisClass.maxEXP = 0;
                }
            }
        }
        //Increase skill points if max level is maxed and skill level isn't maxed
        else if(thisClass.level < thisClass.max)
        {
            thisClass.levelEXP += increaseByLevel;
            //Level Up!!
            if (thisClass.levelEXP >= 100)
            {
                thisClass.levelEXP -= 100;
                thisClass.level += 1;
                thisClass.skillPoints += 1;
                if (thisClass.level == thisClass.max)
                {
                    thisClass.levelEXP = 0;
                }
            }
        }
        else
        {
            Debug.Log("Max level reached!");
        }
    }

    void IncreaseTime()
    {
        if(clock.hours == 7 || (clock.hours == 8 && clock.minutes < 30)){
            clock.hours = 8;
            clock.minutes = 30;
        }else if (clock.hours == 9 || (clock.hours == 10 && clock.minutes < 30))
        {
            clock.hours = 10;
            clock.minutes = 30;
        }
        else if (clock.hours == 12 || (clock.hours == 13 && clock.minutes < 30))
        {
            clock.hours = 13;
            clock.minutes = 30;
        }
        else if (clock.hours == 14 || (clock.hours == 15 && clock.minutes < 30))
        {
            clock.hours = 15;
            clock.minutes = 30;
        }
        else if (clock.hours == 16 || (clock.hours == 17 && clock.minutes < 30))
        {
            clock.hours = 17;
            clock.minutes = 30;
        }
        else
        {
            Debug.Log("How did they get in here at this time?");
        }
    }

    void LeaveClassroom()
    {
        //Resume movement and return to schoolgrounds
        player.GetComponent<Player>().paused = false;
        GatewayManager.Instance.SetSpawnPosition(spawnLocation);
        SceneManager.LoadScene(sceneName);
    }
}
