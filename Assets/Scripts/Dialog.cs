using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [Tooltip("캐릭터 이름")]
    public string name;
    [Tooltip("대사")]
    public string context;
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
}
