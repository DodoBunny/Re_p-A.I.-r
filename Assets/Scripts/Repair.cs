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
    public string name; //���� �׸� �̸� ex)�ϵ���� ����
    public int cost; //�������
    public RepairDivision division = RepairDivision.None; //���� �׸� ����
}
