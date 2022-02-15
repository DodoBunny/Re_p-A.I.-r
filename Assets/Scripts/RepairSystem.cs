using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepairSystem : MonoBehaviour
{
    public GameObject repairUI_contentObj;
    public TextMeshProUGUI repairUI_LogText;

    [SerializeField]
    GameObject rePairUI_ButtonObj;

    [SerializeField]
    public static List<Repair> repairs = new List<Repair>();

    [SerializeField]
    public static Dictionary<Repair, bool> UI_Repairs = new Dictionary<Repair, bool>();

    public int repairCost = 0;
    private void Awake()
    {
        Parse("RepairList");
    }
    void Start()
    {
        for (int i = 0; i < repairs.Count; i++)
        {
            UI_Repairs.Add(repairs[i], false);
            GameObject btn = Instantiate(rePairUI_ButtonObj, repairUI_contentObj.transform);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = repairs[i].r_name;
            Repair_Btn btnData = btn.GetComponent<Repair_Btn>();
            btnData.btn_id = i;
            btnData.btn_active = false;
        }
    }

    string temp;
    private void Update()
    {
        repairCost = 0;
        temp = "[수리계획서]\n";
        for (int i = 0; i < repairs.Count; i++)
        {
            if (UI_Repairs[repairs[i]] == true)
            {
                temp += repairs[i].r_name + " / ";
                repairCost += repairs[i].cost;
            }
        }
        temp += "\n총 수리 비용 : " + repairCost;
        repairUI_LogText.text = temp;
    }

    public void RepairStart()
    {
        int needRepairCount = Character.currentCharacter.breakdownCount;
        for (int i = 0; i < repairs.Count; i++)
        {
            Repair repair = repairs[i];
            if(UI_Repairs[repair] && Character.currentCharacter.breakdownList[repair])
            {
                needRepairCount--;
                Debug.Log(repairs[i].r_name + " 수리");
            }
        }

        if (needRepairCount == 0)
        {
            Debug.Log("수리 성공!");
            Character.currentCharacter.isBreakdown = false;
        }

        SoundSystem.instance.PlaySoundEffect(5);
        SceneSystem.instance.OnScene1();
    }


    //CSV
    public static void Parse(string _CSVFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split('\n');

        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');

            Repair repair = new Repair();

            repair.id = int.Parse(row[0]);
            repair.r_name = row[1];
            switch (row[2])
            {
                case "Hardware":
                    repair.division = RepairDivision.Hardware;
                    break;
                case "SoftWare":
                    repair.division = RepairDivision.Software;
                    break;
                case "Tuning":
                    repair.division = RepairDivision.Tuning;
                    break;
            }
            repair.cost = int.Parse(row[3]);
            repairs.Add(repair);
        }
    }
}
