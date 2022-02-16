using UnityEngine;
using System.Collections;

public class MainSystem : MonoBehaviour
{
    public static MainSystem instance;

    public Character[] characterData;
    public Character tempCharacter;
    public bool isEnd = true;
    private readonly string[] events = { "Day1", "Day2", "Day3", "Day4", "Day5", "Day6", "Day7" };
    private int day = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tempCharacter = Instantiate(characterData[0]);
        DialogSystem.instance.SetEvent(events[day]);
    }

    public void NextEvent()
    {
        day++;
        DialogSystem.instance.SetEvent(events[day]);
    }

    private void Update()
    {

    }
}
