using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public static SceneSystem instance;
    public GameObject Scene1;
    public GameObject Scene2;
    public Image Fade;
    public float FadeSpeed = 0.01f;

    public GameObject button;

    public void OnScene1()
    {
        StartCoroutine(FadeIn(1));
    }

    public void OnScene2()
    {
        StartCoroutine(FadeIn(2));
    }
    
    void OnGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GameStart()
    {
        StartCoroutine(FadeIn());
        Invoke("OnGameScene", 1f);
    }

    IEnumerator FadeIn(int SceneNum)
    {
        Fade.gameObject.SetActive(true);
        float fadeCount = 0;

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(FadeSpeed);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }

        Scene1.SetActive(false);
        Scene2.SetActive(false);
        switch (SceneNum)
        {
            case 1:
                Scene1.SetActive(true);
                break;
            case 2:
                Scene2.SetActive(true);
                break ;
        }

        while (fadeCount > 0)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(FadeSpeed);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }

        Fade.gameObject.SetActive(false);
    }

    IEnumerator FadeIn()
    {
        Fade.gameObject.SetActive(true);
        float fadeCount = 0;

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(FadeSpeed);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }
    }

    IEnumerator FadeOut()
    {
        Fade.gameObject.SetActive(true);
        float fadeCount = 1;

        while (fadeCount > 0)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(FadeSpeed);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }

        Fade.gameObject.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
        StartCoroutine(FadeOut());
    }
    private void Update()
    {
        if (Character.currentCharacter == null)
            button.gameObject.SetActive(false);
        else
            button.gameObject.SetActive(true);
    }
}
