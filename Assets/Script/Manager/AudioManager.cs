using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider slider;
    public GameObject downBar;
    public GameObject upBar;
    AudioSource audio;
    bool isDonDestroyObhectNull = true;
    bool isPlay = false;
    private void Awake()
    {
        var obj = FindObjectsOfType<AudioManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        isPlay = true;
        boolSaver.bRealTalk = true;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "RealTalk1" || SceneManager.GetActiveScene().name == "SampleScene Android 9 x 16")
        {
            boolSaver.bDiary = false;
        }
        if (boolSaver.bDiary == false && isPlay == true)
        {
            isPlay = false;
            audio.Stop();
        }
        else if (boolSaver.bDiary == true && isPlay == false)
        {
            isPlay = true;
            audio.Play();
        }
        audio.volume = slider.value;
        if (boolSaver.bRealTalk == true)
        {
            Fungus.MusicManager.volume = slider.value; //설정해놓은 값을 Fungus 에셋의 오디오소스 볼륨에 적용시킴
        }
        if(boolSaver.bRealTalk == true)
        {
            //downBar.SetActive(true);
            upBar.SetActive(true);
        }
        if (boolSaver.bDiary == true)
        {
            Fungus.MusicManager.volume = 0;
            //downBar.SetActive(false);
            upBar.SetActive(true);
        }
        if (boolSaver.bMiniGame == true)
        {
            upBar.SetActive(false);
            //downBar.SetActive(false);
        }
    }
}
