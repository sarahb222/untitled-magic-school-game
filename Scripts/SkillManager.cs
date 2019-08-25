using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skills playerSkills;

    void Start()
    {
        playerSkills = Initialize(playerSkills);
    }

    private Skills Initialize(Skills skills)
    {
        skills = new Skills();
        skills.fire = new Skills.SkillStats();
        skills.water = new Skills.SkillStats();
        skills.earth = new Skills.SkillStats();

        CreateStats(skills.fire);
        CreateStats(skills.water);
        CreateStats(skills.earth);

        return skills;
    }

    private Skills.SkillStats CreateStats(Skills.SkillStats stat)
    {
        stat.max = 1;
        stat.maxEXP = 0;
        stat.level = 0;
        stat.levelEXP = 0;

        return stat;
    }
}
