using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public static Character currentCharacter;
    public int Char_id;
    public string Char_name = "test";
    public int Char_spriteNum;
    public string Char_breakdown;
    public Dictionary<Repair, bool> character_Breakdown = new();

    // Start is called before the first frame update
    public void SetBreakDown()
    {
        Char_breakdown = Char_breakdown.Replace("＼”", "");
        string[] temp = Char_breakdown.Split(',');
        int[] breakNum = new int[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            breakNum[i] = int.Parse(temp[i]);
        }

        for (int i = 0; i < RepairSystem.repairs.Count; i++)
        {
            for (int j = 0; j < breakNum.Length; j++)
            {
                if (breakNum[j] == i)
                {
                    character_Breakdown[RepairSystem.repairs[i]] = true;
                }
                else
                {
                    character_Breakdown[RepairSystem.repairs[i]] = false;
                }
            }
        }
    }

    public void SetCurrentCharacter()
    {
        currentCharacter = this;
    }

    public static Character[] Parse(string _CSVFileName)
    {
        List<Character> characters = new List<Character>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split('\n');

        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');
            Character character = new Character();

            character.Char_id = int.Parse(row[0]);
            character.Char_name = row[1];
            character.Char_spriteNum = int.Parse(row[2]);

            for (int j = 3; j < row.Length; j++)
            {
                character.Char_breakdown += row[j];
            }
            character.SetBreakDown();
            characters.Add(character);
        }

        return characters.ToArray();
    }


}
