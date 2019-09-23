using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textBack = null;
    private GameObject description = null;
    private GameObject currentLevel = null;
    private GameObject nextLevel = null;
    private GameObject levelAmount = null;
    public SkillMaster skillMaster;
    private Skills playerSkills;
    private Skills.SkillStats thisSkillStat;
    private int skillToCheck;

    void Start()
    {
        textBack.SetActive(false);
    }

    void OnEnable()
    {
        description = textBack.transform.Find("Description").gameObject;
        currentLevel = textBack.transform.Find("CurrentLevel").gameObject;
        nextLevel = textBack.transform.Find("NextLevel").gameObject;
        levelAmount = textBack.transform.Find("LevelAmount").gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    { //Make it visible when you hover
        textBack.SetActive(true);

        UpdateHoverText();
    }
    
    public void UpdateHoverText()
    {
        //Find the skill we are working with
        playerSkills = skillMaster.GetComponent<SkillMaster>().playerSkills.playerSkills;

        //Display different text depending on which skill
        //1ST - Fire skills
        if (this.name == "Fireball")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill1;
            description.GetComponent<Text>().text = "Fireball\nBasic Fire Attack";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if(skillToCheck == 1)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 1 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 2 skills here";
            }
            else if (skillToCheck == 2)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 2 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 3 skills here";
            }
            else if (skillToCheck == 3)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 3 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 4 skills here";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 4 skills here";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/4";
        }
        else if(this.name == "Flame Barrier")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill2a;
            description.GetComponent<Text>().text = "Flame Barrier\nInflict dmg on opponent when hit";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if(skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Fireball Lv2";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 1 skills here";
            } else if (skillToCheck == 1)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 1 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 2 skills here";
            }
            else if (skillToCheck == 2)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 2 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 3 skills here";
            }
            else if (skillToCheck == 3)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 3 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 4 skills here";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 4 skills here";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/4";
        }
        else if (this.name == "Quick Cast Fire")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill2b;
            description.GetComponent<Text>().text = "Quick Fire Cast\nCast fire more quickly.";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\n1.5x Speed";
            }
            else if (skillToCheck == 1)
            {
                currentLevel.GetComponent<Text>().text += "\n1.5x Speed";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\n2x Speed";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\n2x Speed";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/2";
        }
        else if (this.name == "Sparks")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill3a;
            description.GetComponent<Text>().text = "Sparks\nIncrease Fire Damage";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Flame Barrier Lv2";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\n1.5x Fire Dmg";
            }
            else if (skillToCheck == 1)
            {
                currentLevel.GetComponent<Text>().text += "\n1.5x Fire Dmg";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\n2x Fire Dmg";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\n2x Fire Dmg";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/2";
        }
        else if (this.name == "Dynamite")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill3b;
            description.GetComponent<Text>().text = "Dynamite\nIncrease Mining Range";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Flame Barrier Lv1, Quick Cast Fire Lv1";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 1 skills here";
            }
            else if (skillToCheck == 1)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 1 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 2 skills here";
            }
            else if (skillToCheck == 2)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 2 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 3 skills here";
            }
            else if (skillToCheck == 3)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 3 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 4 skills here";
            }
            else if (skillToCheck == 4)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 4 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 5 skills here";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 5 skills here";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/5";
        }
        else if (this.name == "Fireworks")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill3c;
            description.GetComponent<Text>().text = "Fireworks\nIncrease Mine Yield";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Quick Cast Fire Lv2";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 1 skills here";
            }
            else if (skillToCheck == 1)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 1 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 2 skills here";
            }
            else if (skillToCheck == 2)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 2 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 3 skills here";
            }
            else if (skillToCheck == 3)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 3 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 4 skills here";
            }
            else if (skillToCheck == 4)
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 4 skills here";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nlevel 5 skills here";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nlevel 5 skills here";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/5";
        }
        else if (this.name == "Mine Teleport")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill4a;
            description.GetComponent<Text>().text = "Mine Teleport\nTeleport to the Mine";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Sparks Lv2";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nTeleport to mine";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nTeleport to mine";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/1";
        }
        else if (this.name == "Flame Spirit")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill4b;
            description.GetComponent<Text>().text = "Flame Spirit\nIncrease Tomorrow's Mine Nodes";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Dynamite Lv5, Fireworks Lv5";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nMine Nodes Increase";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nMine Nodes Increase";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/1";
        }
        else if (this.name == "Volcano")
        {
            thisSkillStat = playerSkills.fire;
            skillToCheck = thisSkillStat.skill5;
            description.GetComponent<Text>().text = "Volcano\nBig Fire Attack";
            currentLevel.GetComponent<Text>().text = "Current Level: " + skillToCheck;
            //Check the level of the skill and adjust text accordingly
            if (skillToCheck == 0)
            {
                currentLevel.GetComponent<Text>().text += "\nReq: Mine Teleport Lv1, Flame Spirit Lv1";

                nextLevel.GetComponent<Text>().text = "Next Level: " + (skillToCheck + 1) + "\nBig fire attack";
            }
            else
            {
                currentLevel.GetComponent<Text>().text += "\nBig fire attack";

                nextLevel.GetComponent<Text>().text = "Max level reached!";
            }

            levelAmount.GetComponent<Text>().text = "Level " + skillToCheck + "/1";
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBack.SetActive(false);
    }


}