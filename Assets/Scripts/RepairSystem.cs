using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSystem : MonoBehaviour
{
    [SerializeField]
    List<Repair> repairs = new List<Repair>();

    [SerializeField]
    public Dictionary<Repair,bool> UI_Repairs = new Dictionary<Repair,bool>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < repairs.Count; i++)
        {
            UI_Repairs.Add(repairs[i], false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
