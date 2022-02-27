using UnityEngine;
using System.Collections;

public class MainSystem : MonoBehaviour
{
    public static MainSystem instance;

    public Character[] characterData;
    public bool isEnd = true;
    public string[] events = { "Day1", "Day1_A", "Day1_AA", "Day2", "Day5", "Day6", "Day7" };
    private int day = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DialogSystem.instance.SetEvent(events[day]);
    }

    public void NextEvent()
    {
        day++;
        DialogSystem.instance.SetEvent(events[day]);
    }

    void AddCharacter()
    {
        Instantiate(characterData[0]);
    }
}
