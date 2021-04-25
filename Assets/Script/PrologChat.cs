using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrologChat : MonoBehaviour
{
    public GameObject[] Comunication;
    public RectTransform[] ComuUI;
    new AudioSource audio;
    public AudioClip Broke;
    public Slider Guage;

    static public float DeleteSpeed;
    private void Awake()
    {
        DeleteSpeed = 1;
        audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        StartCoroutine("ComuSystem");
    }

    void Update()
    {

    }
    private void ChatToUp(int ComuArr, int RectArr, int MaxArr)
    {
        Comunication[ComuArr].SetActive(false);
        for (int i = RectArr; i < MaxArr; i++)
        {
            ComuUI[i].position = new Vector3(ComuUI[i].position.x, ComuUI[i].position.y + 1.2f, ComuUI[i].position.z);
        }
        Comunication[ComuArr].SetActive(false);
    }
    IEnumerator ComuSystem()
    {
        int ComuArr, RectArr, MaxArr;
        ComuArr = 0; RectArr = 1; MaxArr = 6;
        for (int i = 0; i < 6; i++)
        {
            Comunication[i].SetActive(true);
            yield return new WaitForSeconds(DeleteSpeed);
            if (i == 3)
            {
                Guage.value -= 0.09f;
            }
        }
        for (int i = 6; i < 35; i++)
        {
            ChatToUp(ComuArr, RectArr, MaxArr);
            ComuArr++; RectArr++; MaxArr++;
            Comunication[i].SetActive(true);
            yield return new WaitForSeconds(DeleteSpeed);
            if (i == 7 || i == 11 || i == 16 || i == 18 || i == 21 || i == 25 || i == 26 || i == 28 || i == 30 || i == 33)
            {
                Guage.value -= 0.09f;
            }
        }
        Guage.value -= 50000000000;
        //Handheld.Vibrate();
        audio.clip = Broke;
        audio.Play();
        yield return new WaitForSeconds(5);
        StartCoroutine("FadeOut");

    }
    public Image Panel;

    float time = 0f;
    float F_time = 2f;
    IEnumerator FadeOut()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("RealTalk");

        yield return null;
    }
}