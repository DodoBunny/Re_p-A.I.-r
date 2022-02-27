using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainSystem : MonoBehaviour
{
    public static MainSystem instance;
    public GameObject CharPool;
    public Character[] characterData;
    public bool isEnd = true;
    public string[] events = { "Day0", "Day1_A", "Day1_AA", "Day2", "Day5", "Day6", "Day7" };
    private int day = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Debug.Log(day);
        DialogSystem.instance.SetEvent(events[day]);
    }

    public void NextEvent()
    {
        day++;
        DialogSystem.instance.SetEvent(events[day]);
    }

    public void AddCharacter(int CharNum)
    {
         Instantiate(characterData[CharNum],CharPool.transform);
    }

    public void SetRepairCharacter(int CharNum)
    {
        characterData[CharNum].SetCurrentCharacter();
    }

    public void RemoveCharacter(int CharNum)
    {
        Character[] characters = CharPool.GetComponentsInChildren<Character>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].char_id == CharNum)
                Destroy(characters[i].gameObject);
        }
    }
}
