using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllocatePoints : MonoBehaviour
{
    public SkillMaster skillMaster;
    private Skills playerSkills;
    private Skills.SkillStats thisSkillStat;
    private int skillToCheck;
    

    public void AllocateSkillPoints()
    {
        //Find the skill we are working with
        playerSkills = skillMaster.GetComponent<SkillMaster>().playerSkills.playerSkills;

        if (this.name == "Fireball")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill1;
                //Check if the skill points allocated are less than max
                if (skillToCheck < 4)
                {
                    thisSkillStat.skill1++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        else if (this.name == "Flame Barrier")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill2a;
                //Check if prereq is met
                if (thisSkillStat.skill1 < 2)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 4)
                {
                    thisSkillStat.skill2a++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        else if (this.name == "Quick Cast Fire")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill2b;
                //Check if the skill points allocated are less than max
                if (skillToCheck < 2)
                {
                    thisSkillStat.skill2b++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        else if (this.name == "Sparks")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill3a;
                //Check if prereq is met
                if (thisSkillStat.skill2a < 2)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 2)
                {
                    thisSkillStat.skill3a++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }

            }
        }
        else if (this.name == "Dynamite")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill3b;
                //Check if prereq is met
                if (thisSkillStat.skill2a < 1 || thisSkillStat.skill2b < 1)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 5)
                {
                    thisSkillStat.skill3b++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        else if (this.name == "Fireworks")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill3c;
                //Check if prereq is met
                if (thisSkillStat.skill2b < 2)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 5)
                {
                    thisSkillStat.skill3c++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        else if (this.name == "Mine Teleport")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill4a;
                //Check if prereq is met
                if (thisSkillStat.skill3a < 2)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 1)
                {
                    thisSkillStat.skill4a++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        else if (this.name == "Flame Spirit")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill4b;
                //Check if prereq is met
                if (thisSkillStat.skill3b < 5 || thisSkillStat.skill3c < 5)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 1)
                {
                    thisSkillStat.skill4b++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        else if (this.name == "Volcano")
        {
            thisSkillStat = playerSkills.fire;

            //Check if there are any skill points first
            if (thisSkillStat.skillPoints == 0)
            {
                return;
            }
            else
            {
                skillToCheck = thisSkillStat.skill5;
                //Check if prereq is met
                if (thisSkillStat.skill4a < 1 || thisSkillStat.skill4b < 1)
                {
                    return;
                }
                //Check if the skill points allocated are less than max
                else if (skillToCheck < 1)
                {
                    thisSkillStat.skill5++;
                    thisSkillStat.skillPoints--;
                    this.GetComponentInParent<SkillChanger>().UpdateChanges();
                    this.GetComponent<HoverText>().UpdateHoverText();
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        return;
    }
}
