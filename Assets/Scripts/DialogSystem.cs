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

    public TextMeshProUGUI target;
    public TextMeshProUGUI logText;
    public GameObject logBox;
    public float textSpeed = 0.15f;

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
        KeyInput();
        SetActiveUI();
    }

    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTalking == false)
            {
                UpdateDialog();
            }
        }
    }

    public void UpdateDialog()
    {
        string str = TextData.GetText();
        if (TextData.isTextEnd)
            return;

        typingEft = _typing(str);
        StartCoroutine(typingEft);
    }

    public void UpdateLog()
    {
        logText.text = TextData.GetLogText();
    }

    void SetActiveUI()
    {
        if (isTalking == true)
            textEndIcon.SetActive(false);
        else
            textEndIcon.SetActive(true);
    }

    public void StopTyping()
    {
        StopCoroutine(typingEft);
    }

    bool isLogBoxActive = false;
    public void LogBoxOn()
    {
        if(isLogBoxActive == false)
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

    IEnumerator _typing(string text)
    {
        isTalking = true;
        //yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < text.Length + 1; i++)
        {
            target.text = TextData.currentNpcName + text.Substring(0, i);
            if (target.text.EndsWith(' ') == false)
                audio.Play();
            yield return new WaitForSeconds(textSpeed);
        }
        UpdateLog();
        isTalking = false;
    }
}
