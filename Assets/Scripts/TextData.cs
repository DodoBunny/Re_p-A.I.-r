using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextData : Singleton<GameManager>
{
    public TextData()
    {
        //초기화
    }

    static string[] currentTexts = new string[999];
    static int currentTextLenght = 0;
    static int textLenght = 0;
    static string defaultPath = "Assets/Text/";
    static public bool isTextEnd = true;
    static public DialogSystem dialog;

    public static void SetText(string fileName, bool autoStart = true)
    {
        //초기화
        currentTexts = new string[1];
        currentTextLenght = 0;
        dialog.StopTyping();

        string filePath = defaultPath + fileName + ".txt";
        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";
        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            currentTexts = value.Split('\n');
            textLenght = currentTexts.Length;
            isTextEnd = false;
            dialog.StopTyping();
            if (autoStart)
                dialog.UpdateDialog();
            reader.Close();
        }
        else
        {
            currentTexts[0] = "텍스트 파일 불러오기 에러 : " + fileName + ".txt";
            textLenght = 1;
            isTextEnd = false;
            dialog.UpdateDialog();
        }
    }

    public static string GetText()
    {
        if (currentTextLenght == textLenght)
        {
            isTextEnd = true;
            return null;
        }
        string value = currentTexts[currentTextLenght];
        currentTextLenght++;
        return value;
    }

    public static void UpdateDialog()
    {
        dialog.UpdateDialog();
    }
}
