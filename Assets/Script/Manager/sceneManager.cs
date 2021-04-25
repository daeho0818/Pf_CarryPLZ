using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void LoadLogoScene()
    {
        SceneManager.LoadScene("LogoScene");
    }
    public void Messenger()
    {
        SceneManager.LoadScene("Messenger");
    }
    public void LoadChating()
    {
        SceneManager.LoadScene("Chating");
    }
    public void LoadFriend1Scene()
    {
        SceneManager.LoadScene("Friend1Comu");
    }
    public void LoadFriend2Scene()
    {
        SceneManager.LoadScene("Friend2Comu");
    }
    public void LoadFriend3Scene()
    {
        SceneManager.LoadScene("Friend3Comu");
    }
    public void GoToDiary()
    {
        if (DayManager.dayNum == 0 || DayManager.dayNum == 2 || DayManager.dayNum == 4 || DayManager.dayNum == 6)
        {
            SceneManager.LoadScene("Diary");
            boolSaver.bDiary = true;
            boolSaver.bRealTalk = false;
            boolSaver.bMiniGame = false;
            UIManager.time = 0;
        }
        else if (DayManager.dayNum == 1 || DayManager.dayNum == 3 || DayManager.dayNum == 5)
        {
            SceneManager.LoadScene("miniGame");
            boolSaver.bRealTalk = false;
            boolSaver.bDiary = false;
            boolSaver.bMiniGame = true;
        }
    }
    public void NextDay()
    {
        if (DayManager.dayNum == 0 || DayManager.dayNum == 2 || DayManager.dayNum == 4)
        {
            SceneManager.LoadScene("RealTalk1");
            boolSaver.bDiary = false;
            boolSaver.bRealTalk = true;
            boolSaver.bMiniGame = false;
        }
        else if (DayManager.dayNum == 1 || DayManager.dayNum == 3 || DayManager.dayNum == 5)
        {
            // 채팅씬!
            SceneManager.LoadScene("SampleScene Android 9 x 16");
            boolSaver.bDiary = false;
            boolSaver.bRealTalk = false;
            boolSaver.bMiniGame = false;
        }
        else if(DayManager.dayNum == 6)
        {
            SceneManager.LoadScene("RealTalk1");
            boolSaver.bDiary = false;
            boolSaver.bRealTalk = true;
            boolSaver.bMiniGame = false;
        }
        else // 임시엔딩으로
        { 
            SceneManager.LoadScene("Ending");
        }
    }
    public void GoToMiniGame()
    {
        SceneManager.LoadScene("Tutorial_miniGame");
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Diary")
        {
            boolSaver.bDiary = true;
        }
    }
}