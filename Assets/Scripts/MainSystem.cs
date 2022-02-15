using UnityEngine;
using System.Collections;

public class MainSystem : MonoBehaviour
{
    public static Character[] characters;
    // Use this for initialization
    void Start()
    {
        characters = Character.Parse("Character");
        characters[0].SetCurrentCharacter();

        for (int i = 0; i < RepairSystem.repairs.Count; i++)
        {
            bool temp = Character.currentCharacter.character_Breakdown[RepairSystem.repairs[i]];
            Debug.Log($"{RepairSystem.repairs[i].r_name} : {temp}");
        }
    }
}
