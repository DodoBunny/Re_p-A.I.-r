using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneSystem : MonoBehaviour
{
    public GameObject Scene1;
    public GameObject Scene2;
    public Image Fade;
    public float FadeSpeed = 0.01f;

    public void OnScene1()
    {
        StartCoroutine(FadeIn(1));
    }

    public void OnScene2()
    {
        StartCoroutine(FadeIn(2));
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

}
