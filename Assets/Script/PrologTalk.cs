using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologTalk : MonoBehaviour
{
    public GameObject[] TalkBox;
    public GameObject[] images;
    public Text[] text;
    [Space (10f)]
    public Text Name;
    [Space(10f)]
    public Image Panel;
    List<string> strText = new List<string>();
    private float chatSpeed = 3, time = 0f, F_time = 0.5f;
    private void Awake()
    {
        strText.Add("...떠");
        strText.Add("...좀 떠봐...");
        strText.Add("여긴...?");
        strText.Add("저 결국 고혈압으로 죽은 건가요?");
        strText.Add("일단 눈부터 제대로 떠봐.");
        strText.Add("????");
        strText.Add("안녕! 조장아. 반가워! 나는 너의 학점을 수호하기 위해 찾아온 학점요정이야!");
        strText.Add("이게 무슨 개꿈이지.");
        strText.Add("눈치가 빠른 편이구나! 네 말대로 여긴 너의 꿈의 세계야. 정확하게 말하면 너의 정신세계지.");
        strText.Add("꿈이라고...?");
        strText.Add("그럼 그 팀플도 꿈?");
        strText.Add("와 너무 다행이다. 정말 그런 사람들이 모여 있는 팀이면 무조건 재수강이지. 휴 진짜 다행이다.");
        strText.Add("그건 꿈 아닌데?");
        strText.Add("어?");
    }
    void Start()
    {
        StartCoroutine(TalkSystem());
    }
    IEnumerator TalkSystem()
    {
        int a = 0;
        for (int i = 0; i < strText.Count; i++)
        {
            if (i == 0 || i == 1 || i == 4 || i == 6 || i == 8 || i == 12)
            {
                if (i == 0 || i == 1 || i == 4)
                {
                    Name.text = "???";
                }
                else
                {
                    Name.text = "학점요정";
                }
                text[0].text = strText[i];
                TalkBox[0].SetActive(true); //학점요정 TalkBox
                TalkBox[1].SetActive(false);
                yield return new WaitForSeconds(chatSpeed);
            }
            else
            {
                text[1].text = strText[i];
                TalkBox[0].SetActive(false);
                TalkBox[1].SetActive(true); //나 TalkBox
                yield return new WaitForSeconds(chatSpeed);
            }
            if (i == 1 || i == 4 || i == 5)
            {
                if (i == 4)
                {
                    Panel.gameObject.SetActive(true);
                    //FadeInOut();
                    //FadeOut
                    Color alpha = Panel.color;
                    while (alpha.a < 1)
                    {
                        time += Time.deltaTime / F_time;
                        alpha.a = Mathf.Lerp(0, 1, time);
                        Panel.color = alpha;
                        yield return null;
                    }
                    yield return new WaitForSeconds(chatSpeed);
                    //FadeIn
                    while (alpha.a > 0)
                    {
                        time -= Time.deltaTime / F_time;
                        alpha.a = Mathf.Lerp(0, 1, time);
                        Panel.color = alpha;
                        yield return null;
                    }
                    yield return null;
                }
                images[a].SetActive(true);
                a++;
            }
        }
        for (int i = 0; i < strText.Count; i++)
        {
            strText[i].Remove(i);
        }
    }
    void FadeInOut()
    {
        StartCoroutine(FadeOut());
        Debug.Log("FadeInOut");
        StartCoroutine(FadeIn());
    }
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
    }
    IEnumerator FadeIn()
    {
        Color alpha = Panel.color;
        while (alpha.a > 0)
        {
            time -= Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        yield return null;
    }
}