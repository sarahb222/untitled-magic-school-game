using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skills skills;

    void Start()
    {
        CreateStats(skills.fire);
        CreateStats(skills.water);
        CreateStats(skills.earth);
    }

    private Skills.SkillStats CreateStats(Skills.SkillStats stat)
    {
        stat.level = 0;
        stat.max = 5;
        stat.EXP = 50;

        return stat;
    }
}
