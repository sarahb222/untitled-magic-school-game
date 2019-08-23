using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skills
{
    public SkillStats fire;
    public SkillStats water;
    public SkillStats earth;

    [System.Serializable]
    public class SkillStats
    {
        public int max;
        public int level;
        public float EXP;

    }
}
