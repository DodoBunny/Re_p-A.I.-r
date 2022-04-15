using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepairText : MonoBehaviour
{
    static RepairText instance;
    TextMeshProUGUI target;


    public TextMeshProUGUI buttonText;
    public bool isScan = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        target = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.currentCharacter != null)
        {
            if (isScan)
            {
                buttonText.text = "정보 보기";
                target.text = Character.currentCharacter.scanText.Replace('@', '\n');
            }
            else
            {
                buttonText.text = "정밀 스캔";
                target.text = Character.currentCharacter.text.Replace('@', '\n');
            }
        }
    }
    private void OnEnable()
    {
        isScan = false;
    }
    public void Scan()
    {
        isScan = isScan ? false : true;
    }

}
