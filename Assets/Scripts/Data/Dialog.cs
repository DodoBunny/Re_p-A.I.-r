using System;
using System.Collections.Generic;
using UnityEngine;
public class Dialog
{
    [Tooltip("캐릭터 이름")]
    public string name;
    [Tooltip("대사")]
    public string context;

    public int mood = 0;
    public Vector2 eventTriger;
}
public class DialogEvent
{
    public string name; //대화 이름

    public int totalLine;
    public int currentLine;

    public Dialog[] dialogs;

    public bool isTextEnd = false;

    public string GetCurrentText()
    {
        return dialogs[currentLine].context;
    }
    public string GetCurrentName()
    {
        return dialogs[currentLine].name;
    }

    public float GetMood()
    {
        return dialogs[currentLine].mood;
    }
    public void CheckEvent()
    {
        if(dialogs[currentLine].eventTriger != null)
        {
            int eventNum = (int)dialogs[currentLine].eventTriger.x;
            int eventTarget = (int)dialogs[currentLine].eventTriger.y;

            switch (eventNum)
            {
                case 1:
                    MainSystem.instance.AddCharacter(eventTarget);
                    break;
                case 2:
                    MainSystem.instance.SetRepairCharacter(eventTarget);
                    break;
                case 3:
                    MainSystem.instance.DisappearCharacter(eventTarget);
                    break;
                case 4:
                    SceneSystem.instance.OnNextDay();
                    break;
                case 5:
                    MainSystem.instance.GameEnding();
                    break;
                case 6:
                    SoundSystem.instance.PlaySoundEffect(6);
                    SceneSystem.instance.OnLobbyScene();
                    break;
            }
        }
    }
}
