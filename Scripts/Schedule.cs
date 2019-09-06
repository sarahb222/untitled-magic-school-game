using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Schedule
{
    public Classes mw;
    public Classes tth;
    public Classes f;

    [System.Serializable]
    public class Classes
    {
        public String A;
        public String B;
        public String C;
        public String D;
        public String E;

    }
}
