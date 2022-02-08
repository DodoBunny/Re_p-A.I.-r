using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    new AudioSource audio;
    public GameObject textEndIcon;

    bool isTalking = false;

    public TextMeshProUGUI target;
    public float textSpeed = 0.15f;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        TextData.instance.ReadTxt("test");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking == true)
            textEndIcon.SetActive(false);
        else
            textEndIcon.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTalking == false)
            {
                if (TextData.instance.currentTextLenght == TextData.instance.textLenght)
                    return;
                StartCoroutine(_typing(TextData.instance.currentTexts[TextData.instance.currentTextLenght]));
                TextData.instance.currentTextLenght++;
            }
        }

    }

    IEnumerator _typing(string text)
    {
        isTalking = true;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < text.Length; i++)
        {
            target.text = text.Substring(0, i);
            if (target.text.EndsWith(' ') == false)
                audio.Play();
            yield return new WaitForSeconds(textSpeed);
        }
        isTalking = false;
    }
}
