using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChanger : MonoBehaviour
{
    public Button skillClicked;
    public Text skillPointText;
    public SkillMaster skillMaster;
    private Skills playerSkills;
    private Skills.SkillStats thisSkillStat;

    // Update whenever enabled/opened up
    void OnEnable()
    {
        playerSkills = skillMaster.GetComponent<SkillMaster>().playerSkills.playerSkills;
        FindSkill();
        skillPointText.text = "Skill Points: " + thisSkillStat.skillPoints;
    }

    public void UpdateChanges()
    {
        playerSkills = skillMaster.GetComponent<SkillMaster>().playerSkills.playerSkills;
        FindSkill();
        skillPointText.text = "Skill Points: " + thisSkillStat.skillPoints;
    }

    //Find out which skill it is based on the button name
    void FindSkill()
    {
        if(skillClicked.name == "Fire")
        {
            thisSkillStat = playerSkills.fire;
        }else if(skillClicked.name == "Water")
        {
            thisSkillStat = playerSkills.water;
        }
        else if (skillClicked.name == "Earth")
        {
            thisSkillStat = playerSkills.earth;
        }
        else if (skillClicked.name == "Air")
        {
            thisSkillStat = playerSkills.air;
        }
        else if (skillClicked.name == "Animal")
        {
            thisSkillStat = playerSkills.animal;
        }
        else
        {
            thisSkillStat = playerSkills.potions;
        }

        return;
    }

    
}
