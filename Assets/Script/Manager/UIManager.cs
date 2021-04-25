using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] UI;
    public GameObject[] Profile;
    public GameObject[] Picture;

    public GameObject setting;

    public Text dayText;

    public static float time;

    private void Awake()
    {

    }
    public void Setting()
    {
        setting.SetActive(true);
    }
    public void OffSetting()
    {
        setting.SetActive(false);
    }
    public void FreindMenu()
    {
        UI[0].SetActive(true); //친구 목록
        UI[1].SetActive(false);
    }
    public void ChatMenu()
    {
        UI[0].SetActive(false);
        UI[1].SetActive(true); //채팅 목록
    }
    public void SeeProfile1()
    {
        Profile[0].SetActive(true);
    }
    public void CloseProfile1()
    {
        Profile[0].SetActive(false);
    }
    public void SeePicture1()
    {
        Picture[0].SetActive(true);
    }
    public void ClosePicture1()
    {
        Picture[0].SetActive(false);
    }

    public void SeeProfile2()
    {
        Profile[1].SetActive(true);
    }
    public void CloseProfile2()
    {
        Profile[1].SetActive(false);
    }
    public void SeePicture2()
    {
        Picture[1].SetActive(true);
    }
    public void ClosePicture2()
    {
        Picture[1].SetActive(false);
    }

    public void SeeProfile3()
    {
        Profile[2].SetActive(true);
    }
    public void CloseProfile3()
    {
        Profile[2].SetActive(false);
    }
    public void SeePicture3()
    {
        Picture[2].SetActive(true);
    }
    public void ClosePicture3()
    {
        Picture[2].SetActive(false);
    }
    void Update()
    {
        Invoke("DayText", time);
        //DayText();
    }
    void DayText()
    {
        dayText.text = "4월 ";

        if (DayManager.dayNum % 7 == 0)
        {
            dayText.text += DayManager.day + "일 월요일";
        }
        else if (DayManager.dayNum % 7 == 1)
        {
            dayText.text += DayManager.day + "일 화요일";
        }
        else if (DayManager.dayNum % 7 == 2)
        {
            dayText.text += DayManager.day + "일 수요일";
        }
        else if (DayManager.dayNum % 7 == 3)
        {
            dayText.text += DayManager.day + "일 목요일";
        }
        else if (DayManager.dayNum % 7 == 4)
        {
            dayText.text += DayManager.day + "일 금요일";
        }
        else if (DayManager.dayNum % 7 == 5)
        {
            dayText.text += DayManager.day + "일 토요일";
        }
        else if (DayManager.dayNum % 7 == 6)
        {
            dayText.text += DayManager.day + "일 일요일";
        }
    }
}