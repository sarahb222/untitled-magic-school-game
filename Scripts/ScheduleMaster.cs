using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleMaster : MonoBehaviour
{
    public ScheduleManager playerSchedule;
    public GameObject scheduleMaster;
    public static ScheduleMaster Instance { get; set; }

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
        playerSchedule = scheduleMaster.AddComponent<ScheduleManager>();
    }
}
