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
        public int skillPoints;
        public int skill1;
        public int skill2a;
        public int skill2b;
        public int skill3a;
        public int skill3b;
        public int skill3c;
        public int skill4a;
        public int skill4b;
        public int skill5;

    }
}
