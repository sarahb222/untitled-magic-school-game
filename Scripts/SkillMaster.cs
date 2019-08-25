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
        DontDestroyOnLoad(this);
        playerSkills = skillMaster.AddComponent<SkillManager>();
    }
    
}
