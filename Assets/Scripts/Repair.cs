using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RepairDivision
{
    None,
    Hardware,
    Software,
    Tuning
}

[System.Serializable]
public class Repair
{
    public int id;
    public string name; //수리 항목 이름 ex)하드웨어 고장
    public int cost; //수리비용
    public RepairDivision division = RepairDivision.None; //수리 항목 구분
}
