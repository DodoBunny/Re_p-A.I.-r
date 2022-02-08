using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextData
{
    public static TextData instance;
    public TextData()
    {
        if (instance == null)
            instance = this;
    }

    public string[] currentTexts = new string[999];
    public int currentTextLenght = 0;
    public int textLenght = 0;
    string defaultPath = "Assets/Text/";

    public string ReadTxt(string fileName)
    {
        string filePath = defaultPath + fileName + ".txt";
        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";
        if (fileInfo.Exists)
        {
            currentTextLenght = 0;
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            currentTexts = value.Split('\n');
            textLenght = currentTexts.Length;
            reader.Close();
        }

        else
            value = "파일이 없습니다.";

        return value;
    }
}
