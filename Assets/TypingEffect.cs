using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    new AudioSource audio;
    public GameObject textEndIcon;
    public GameObject dialogBox;

    bool isTalking = false;

    public TextMeshProUGUI target;
    public float textSpeed = 0.15f;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        TextData.typingEffect = this;
    }

    void Start()
    {
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
        StartCoroutine(_typing(str));
    }

    void SetActiveUI()
    {
        if (isTalking == true)
            textEndIcon.SetActive(false);
        else
            textEndIcon.SetActive(true);

        if (TextData.isTextEnd)
        {
            dialogBox.SetActive(false);
            target.text = null;
        }
        else 
            dialogBox.SetActive(true);
    }

    IEnumerator _typing(string text)
    {
        isTalking = true;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < text.Length + 1; i++)
        {
            target.text = text.Substring(0, i);
            if (target.text.EndsWith(' ') == false)
                audio.Play();
            yield return new WaitForSeconds(textSpeed);
        }
        isTalking = false;
    }
}
