using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextData : Singleton<TextData>
{
    public TextData()
    {
        //초기화
    }
    static public DialogSystem dialog;

    public static void UpdateDialog()
    {
        dialog.UpdateDialog();
    }

    //CSV
    static DialogEvent Parse(string _CSVFileName)
    {
        List<Dialog> dialogList = new List<Dialog>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split('\n');

        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');

            Dialog dialog = new Dialog();
            dialog.name = row[1];
            dialog.context = row[2];

            dialogList.Add(dialog);
        }
        DialogEvent dialogEvent = new DialogEvent();
        dialogEvent.name = _CSVFileName;
        dialogEvent.currentLine = 0;
        dialogEvent.totalLine = data.Length - 1;
        dialogEvent.dialogs = dialogList.ToArray();

        return dialogEvent;
    }

    public static DialogEvent SetEvent(string _CSVFileName)
    {
        DialogEvent _event = Parse(_CSVFileName);
        dialog.currentDialogEvent = _event;
        return _event;
    }
}

