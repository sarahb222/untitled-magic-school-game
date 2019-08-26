using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMaster : MonoBehaviour
{
    public SkillManager playerSkills;
    public GameObject skillMaster;

    // Start is called before the first frame update
    void Start()
    {
        //Store everyone's skills in this skill master
        DontDestroyOnLoad(this);
        playerSkills = skillMaster.AddComponent<SkillManager>();
    }
    
}
