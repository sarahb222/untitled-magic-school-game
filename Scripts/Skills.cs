using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skills
{
    public SkillStats fire;
    public SkillStats water;
    public SkillStats air;
    public SkillStats earth;
    public SkillStats animal;
    public SkillStats potions;

    [System.Serializable]
    public class SkillStats
    {
        public int max;
        public float maxEXP;
        public int level;
        public float levelEXP;

    }
}
