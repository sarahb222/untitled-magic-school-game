using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillClicker : MonoBehaviour
{
    public GameObject allSkills;
    private GameObject firePoints;
    public void ChangeClicked()
    {
        firePoints = allSkills.transform.Find("FirePoints").gameObject;

        if(this.name == "Fire")
        {
            firePoints.SetActive(true);
        }
        else
        {
            firePoints.SetActive(false);
        }
    }
}
