using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainSystem : MonoBehaviour
{
    public Dictionary<string,int> characterID = new Dictionary<string,int>();

    public static MainSystem instance;
    public GameObject CharPool;
    public Character[] characterData;
    public bool isEnd = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NextEvent(0);
        DialogSystem.instance.UpdateDialog();
        characterID.Add("조세핀", 0);
        characterID.Add("브루스", 1);
        characterID.Add("실베스터", 2);
        characterID.Add("시안", 3);
        characterID.Add("불워크", 4);
        characterID.Add("브루스2", 5);
        characterID.Add("조나스", 6);
        characterID.Add("실베스터2", 7);
        characterID.Add("시안2", 8);
        characterID.Add("마르코", 9);
        characterID.Add("레네", 10);
        characterID.Add("존스턴", 11);


        Debug.Log(DialogSystem.instance.currentDialogEvent.name);
    }

    private int day = 0;
    int temp = 0;
    public void NextEvent(int repairResult)
    {
        switch (day)
        {
            case 0:
                Day1(repairResult);
                break;
            case 1:
                Day2(repairResult);
                break;
            case 2:
                Day3(repairResult);
                break;
            case 3:
                Day4(repairResult);
                break;
            case 4:
                Day5(repairResult);
                break;
            case 5:
                Day6(repairResult);
                break;
            case 6:
                Day7();
                break;
        }
    }

    void Day1(int result)
    {
        switch (temp)
        {
            case 0:
                DialogSystem.instance.SetEvent("Day1");
                temp++;
                break;
            case 1:
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent("Day1A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent("Day1B");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent("Day1C");
                        break;
                }
                temp++;
                break;
            case 2:
                string file = DialogSystem.instance.currentDialogEvent.name;
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent(file + "A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent(file + "B");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent(file + "C");
                        break;
                }
                temp = 0;
                day++;
                break;
        }
    }

    void Day2(int result)
    {
        switch (temp)
        {
            case 0:
                ClearCharacter();
                SceneSystem.instance.OnScene1();
                DialogSystem.instance.SetEvent("Day2");
                temp++;
                break;
            case 1:
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent("Day2A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent("Day2B");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent("Day2C");
                        break;
                }
                temp = 0;
                day++;
                break;
        }
    }
    void Day3(int result)
    {
        switch (temp)
        {
            case 0:
                ClearCharacter();
                SceneSystem.instance.OnScene1();
                DialogSystem.instance.SetEvent("Day3");
                temp++;
                break;
            case 1:
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent("Day3A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent("Day3C");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent("Day3C");
                        break;
                }
                temp++;
                break;
            case 2:
                string file = DialogSystem.instance.currentDialogEvent.name;
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent(file + "A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent(file + "C");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent(file + "C");
                        break;
                }
                temp = 0;
                day++;
                break;
        }
    }

    void Day4(int result)
    {
        switch (temp)
        {
            case 0:
                ClearCharacter();
                SceneSystem.instance.OnScene1();
                DialogSystem.instance.SetEvent("Day4");
                temp++;
                break;
            case 1:
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent("Day4A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent("Day4C");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent("Day4C");
                        break;
                }
                temp = 0;
                day++;
                break;
        }
    }

    void Day5(int result)
    {
        switch (temp)
        {
            case 0:
                ClearCharacter();
                SceneSystem.instance.OnScene1();
                DialogSystem.instance.SetEvent("Day5");
                temp++;
                break;
            case 1:
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent("Day5A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent("Day5C");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent("Day5C");
                        break;
                }
                temp = 0;
                day++;
                break;
        }
    }


    void Day6(int result)
    {
        switch (temp)
        {
            case 0:
                ClearCharacter();
                SceneSystem.instance.OnScene1();
                DialogSystem.instance.SetEvent("Day6");
                temp++;
                break;
            case 1:
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent("Day6A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent("Day6B");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent("Day6C");
                        break;
                }
                temp++;
                break;
            case 2:
                string file = DialogSystem.instance.currentDialogEvent.name;
                switch (result)
                {
                    case 0:
                        DialogSystem.instance.SetEvent(file + "A");
                        break;
                    case 1:
                        DialogSystem.instance.SetEvent(file + "B");
                        break;
                    case 2:
                        DialogSystem.instance.SetEvent(file + "C");
                        break;
                }
                temp = 0;
                day++;
                break;
        }
    }

    void Day7()
    {
        ClearCharacter();
        SceneSystem.instance.OnScene1();
        DialogSystem.instance.SetEvent("Day7");
    }

    public void AddCharacter(int CharNum)
    {
         Instantiate(characterData[CharNum],CharPool.transform);
    }

    public void SetRepairCharacter(int CharNum)
    {
        Character.currentCharacter = characterData[CharNum];
        Character.currentCharacter.SetCurrentCharacter();

        Character[] characters = CharPool.GetComponentsInChildren<Character>();
        
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].char_id == CharNum)
                Destroy(characters[i].gameObject);
        }
    }

    public void DisappearCharacter(int CharNum)
    {
        Character[] characters = CharPool.GetComponentsInChildren<Character>();

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].char_id == CharNum)
                Destroy(characters[i].gameObject);
        }
    }

    public void ClearCharacter()
    {
        Character[] characters = CharPool.GetComponentsInChildren<Character>();

        for (int i = 0; i < characters.Length; i++)
        {
             Destroy(characters[i].gameObject);
        }
    }

    public Animator GetAnimator(int CharNum)
    {
        Character[] characters = CharPool.GetComponentsInChildren<Character>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].char_id == CharNum)
                return characters[i].animator;
        }
        return null;
    }
}
