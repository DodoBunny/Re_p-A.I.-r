using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    new AudioSource audio;
    public GameObject textEndIcon;

    bool isTalking = false;
    string TalkingName;

    public TextMeshProUGUI target;
    public TextMeshProUGUI logText;
    public GameObject logBox;
    public float textSpeed = 0.15f;
    float currentTextSpeed = 0.15f;
    string logString;
    //CSV
    public DialogEvent currentDialogEvent;
    public IEnumerator typingEft;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        TextData.dialog = this;
    }

    void Start()
    {
        typingEft = _typing("");
    }

    // Update is called once per frame
    void Update()
    {
        SetActiveUI();
    }

    #region UIControll
    public void OnTouchArea()
    {
        if (isTalking == false)
        {
            currentTextSpeed = textSpeed;
            UpdateDialog();
        }
        else
        {
            currentTextSpeed = 0;
        }
    }

    public void LogBoxOn()
    {
        if (isLogBoxActive == false)
        {
            logBox.SetActive(true);
            isLogBoxActive = true;
        }
        else
        {
            logBox.SetActive(false);
            isLogBoxActive = false;
        }
    }

    void SetActiveUI()
    {
        if (isTalking == true)
            textEndIcon.SetActive(false);
        else
            textEndIcon.SetActive(true);
    }
    #endregion


    public void UpdateDialog()
    {
        if (currentDialogEvent == null)
            return;
        if (currentDialogEvent.isTextEnd)
            return;
        if (currentDialogEvent.totalLine == currentDialogEvent.currentLine + 1)
        {
            currentDialogEvent.isTextEnd = true;
            return;
        }
        currentDialogEvent.currentLine++;
        Debug.Log($"{currentDialogEvent.currentLine}, {currentDialogEvent.totalLine}");
        TalkingName = currentDialogEvent.GetCurrentName();
        string str = currentDialogEvent.GetCurrentText();
        typingEft = _typing(str);
        StartCoroutine(typingEft);
    }

    public void UpdateLog()
    {
        logString += currentDialogEvent.GetCurrentName() + " : " + currentDialogEvent.GetCurrentText() + "\n";
        logText.text = logString;
    }


    public void StopTyping()
    {
        StopCoroutine(typingEft);
    }

    bool isLogBoxActive = false;


    IEnumerator _typing(string text)
    {
        isTalking = true;
        //yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < text.Length + 1; i++)
        {
            target.text = TalkingName + " : " + text.Substring(0, i);
            if (target.text.EndsWith(' ') == false)
                audio.Play();
            yield return new WaitForSeconds(currentTextSpeed);
        }
        UpdateLog();
        isTalking = false;
    }
}
