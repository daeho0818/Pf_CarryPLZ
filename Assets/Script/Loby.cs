using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Loby : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer fadeRenderer = null;
    [SerializeField]
    private GameObject textObj = null;

    [SerializeField]
    private float fadeSpeed = 2f;
    private bool isFadeIn = false;

    private bool isFirstStart;
    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1080, 1920, false); //해상도 고정
        StartCoroutine(TryFadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn && Input.anyKeyDown)
        {
            if (!isFirstStart)
            {
                isFadeIn = false;
                textObj.SetActive(false);
                StartCoroutine(TryFadeOut());
            }
        }
    }

    IEnumerator TryFadeIn()
    {
        Color color = fadeRenderer.material.color;
        while (color.a > 0.0f)
        {
            color.a -= (0.1f / 255f) * fadeSpeed;
            fadeRenderer.material.color = color;
            yield return null;
        }
        color.a = 0f;
        fadeRenderer.material.color = color;

        textObj.SetActive(true);
        isFadeIn = true;
    }

    IEnumerator TryFadeOut()
    {
        Color color = fadeRenderer.material.color;
        while (color.a < 1.0f)
        {
            color.a += (0.1f / 255f) * fadeSpeed;
            fadeRenderer.material.color = color;
            yield return null;
        }
        color.a = 1f;
        fadeRenderer.material.color = color;

        //화면 이동
        NextDay();
    }
    void NextDay()
    {
        if (DayManager.dayNum == 0 || DayManager.dayNum == 2 || DayManager.dayNum == 4)
        {
            SceneManager.LoadScene("RealTalk1");
        }
        else
        {
            //채팅씬
            SceneManager.LoadScene("SampleScene Android 9 x 16");
        }
    }
}