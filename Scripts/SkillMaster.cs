﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMaster : MonoBehaviour
{
    public SkillManager playerSkills;
    public GameObject skillMaster;
    public static SkillMaster Instance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        //Store everyone's skills in this skill master
        DontDestroyOnLoad(this);
        playerSkills = skillMaster.AddComponent<SkillManager>();
    }
    
}
