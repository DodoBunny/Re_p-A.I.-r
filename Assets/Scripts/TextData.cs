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

    static string[] currentTexts = new string[999];
    static string[] LogTexts = new string[999];
    static int currentTextLenght = 0; //현재까지 대화를 진행한 횟수
    static int textLenght = 0; //텍스트 파일의 총 대화 수
    static string defaultPath = "Assets/Text/";
    static public bool isTextEnd = true; //현재 텍스트파일의 마지막 대화인가?
    static public DialogSystem dialog;
    static public string currentNpcName = "???";

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
            LogTexts = currentTexts; //대화 로그 불러오기 용
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
        int index = value.IndexOf(':') + 1;
        currentNpcName = value.Substring(0, index);
        value = value.Substring(index);
        currentTextLenght++;
        return value;
    }

    public static string GetLogText()
    {
        string log = "";
        for (int i = 0; i < currentTextLenght; i++)
        {
            log += currentTexts[i] + '\n';
        }
        return log;
    }

    public static void UpdateDialog()
    {
        dialog.UpdateDialog();
    }
}
