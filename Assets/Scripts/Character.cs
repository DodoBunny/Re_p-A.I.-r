using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character currentCharacter;

    public int char_id;
    public string char_name = "";
    public Sprite sprite;
    public List<int> char_breakdownID = new();
    public Dictionary<Repair, bool> breakdownList = new();
    public int breakdownCount;
    public bool isBreakdown = true;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetCurrentCharacter()
    {
        currentCharacter = this;
        SetBreakDown();
    }
    
    public void SetBreakDown()
    {
        for (int i = 0; i < RepairSystem.repairs.Count; i++)
        {
            if (char_breakdownID.Contains(i))
            {
                breakdownList[RepairSystem.repairs[i]] = true;
                breakdownCount++;
            }
            else
            {
                breakdownList[RepairSystem.repairs[i]] = false;
            }
        }
    }

}