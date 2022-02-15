using UnityEngine;
using System.Collections;

public class MainSystem : MonoBehaviour
{
    public static MainSystem instance;

    public Character[] characterData;
    public Character tempCharacter;
    public int day = 1;
    public bool isEnd = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tempCharacter = Instantiate(characterData[0]);
        TextData.SetEvent("test");
        TextData.UpdateDialog();
    }

    private void Update()
    {
        if (DialogSystem.instance.currentDialogEvent.isTextEnd)
            Clear();

        if (isEnd)
        {
            switch (day)
            {
                case 1:
                    isEnd = false;
                    break;
                case 2:
                    isEnd = false;
                    break;
                case 3:
                    isEnd = false;
                    break;
                case 4:
                    isEnd = false;
                    break;
                case 5:
                    isEnd = false;
                    break;
                case 6:
                    isEnd = false;
                    break;
                case 7:
                    isEnd = false;
                    break;
            }
        }
    }

    void Clear()
    {
        day++;
        Destroy(tempCharacter.gameObject);
    }
}
