using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public Stat stat;

    void Start()
    {
        CreateStats(stat.fire);
        CreateStats(stat.water);
        CreateStats(stat.earth);
    }

    private Stats CreateStats(Stats stat)
    {
        stat.level = 0;
        stat.max = 5;
        stat.EXP = 50;

        return stat;
    }
}
