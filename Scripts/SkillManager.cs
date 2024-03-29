﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skills playerSkills;

    void Start()
    {
        //Initialize the all skills
        playerSkills = Initialize(playerSkills);
    }

    //Initialize skills
    private Skills Initialize(Skills skills)
    {
        skills = new Skills();
        skills.fire = new Skills.SkillStats();
        skills.water = new Skills.SkillStats();
        skills.air = new Skills.SkillStats();
        skills.earth = new Skills.SkillStats();
        skills.animal = new Skills.SkillStats();
        skills.potions = new Skills.SkillStats();

        CreateStats(skills.fire);
        CreateStats(skills.water);
        CreateStats(skills.air);
        CreateStats(skills.earth);
        CreateStats(skills.animal);
        CreateStats(skills.potions);

        return skills;
    }

    //Create the individual stats
    private Skills.SkillStats CreateStats(Skills.SkillStats stat)
    {
        stat.max = 1;
        stat.maxEXP = 0;
        stat.level = 1;
        stat.levelEXP = 0;
        stat.skillPoints = 0;
        stat.skill1 = 1;
        stat.skill2a = 0;
        stat.skill2b = 0;
        stat.skill3a = 0;
        stat.skill3b = 0;
        stat.skill3c = 0;
        stat.skill4a = 0;
        stat.skill4b = 0;
        stat.skill5 = 0;

        return stat;
    }
}
