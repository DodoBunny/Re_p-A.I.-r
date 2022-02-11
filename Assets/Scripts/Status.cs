using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Status
{
    public Status(string name)
    {

    }

    public string name;

    public enum BreakdownList
    {
        Eye,
        Leg,
        Virus
    }

    void init()
    {
        Dictionary<BreakdownList, bool> isBreakdown = new Dictionary<BreakdownList, bool>();
        isBreakdown.Add(BreakdownList.Eye, false);
        isBreakdown.Add(BreakdownList.Leg, false);
        isBreakdown.Add(BreakdownList.Virus, false);
    }

}
