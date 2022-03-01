using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;
    new AudioSource audio;
    Animator animator;
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
        instance = this;
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        typingEft = _typing("");
    }

    // Update is called once per frame
    void Update()
    {
        SetActiveEndIcon(); 
        Anim();
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
        if (logBox.activeInHierarchy == false)
        {
            logBox.SetActive(true);
        }
        else
        {
            logBox.SetActive(false);
        }
    }
    void Anim()
    {
        if (animator == null)
            return;

        if (isTalking == true)
            animator.SetFloat("Talk", 1);
        else
            animator.SetFloat("Talk", 0);


        float mood = currentDialogEvent.GetMood();
        animator.SetFloat("Mood", mood);

    }
    void SetActiveEndIcon()
    {
        if (isTalking == true)
            textEndIcon.SetActive(false);
        else
            textEndIcon.SetActive(true);
    }
    public void UpdateDialog()
    {
        if (currentDialogEvent == null)
            return;

        if (currentDialogEvent.isTextEnd)
            return;

        /////////////////

        currentDialogEvent.CheckEvent();
        int charID;

        if(MainSystem.instance.characterID.TryGetValue(currentDialogEvent.GetCurrentName(), out charID))
        {
            animator = MainSystem.instance.GetAnimator(charID);
        }
        else
        {
            animator = null;
        }

        ///

        TalkingName = currentDialogEvent.GetCurrentName();
        string str = currentDialogEvent.GetCurrentText();
        typingEft = _typing(str);
        StartCoroutine(typingEft);
        UpdateLog();
        currentDialogEvent.currentLine++;

        if (currentDialogEvent.totalLine == currentDialogEvent.currentLine)
        {
            currentDialogEvent.isTextEnd = true;
            return;
        }
    }

    public void UpdateLog()
    {
        if (currentDialogEvent.isTextEnd)
            return;

        logString += currentDialogEvent.GetCurrentName() + " : " + currentDialogEvent.GetCurrentText() + "\n";
        logText.text = logString;
    }

    public void ResetLog()
    {
        logString = string.Empty;
    }
    #endregion




    public void StopTyping()
    {
        StopCoroutine(typingEft);
    }



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
        isTalking = false;
    }

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
            dialog.context = row[2].Replace('^',',');
            ////////////////////
            if(row[3] != "")
            {
                dialog.mood = int.Parse(row[3]);
            }
            if(row[4] != "")
            {
                dialog.eventTriger = new Vector2(int.Parse(row[4]), int.Parse(row[5]));
            }
                
            /////////////////////
            dialogList.Add(dialog);
        }
        DialogEvent dialogEvent = new DialogEvent();
        dialogEvent.name = _CSVFileName;
        dialogEvent.currentLine = 0;
        dialogEvent.totalLine = data.Length - 1;
        dialogEvent.dialogs = dialogList.ToArray();

        return dialogEvent;
    }

    public void SetEvent(string _CSVFileName)
    {
        ResetLog();
        DialogEvent _event = Parse(_CSVFileName);
        currentDialogEvent = _event;
    }
}
