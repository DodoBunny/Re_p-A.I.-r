using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Char_name = "test";
    public int Char_id;

    [SerializeField]
    public bool[] isBroken = new bool[RepairSystem.repairs.Count];

    public Dictionary<Repair, bool> Character_Repairs = new Dictionary<Repair, bool>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
