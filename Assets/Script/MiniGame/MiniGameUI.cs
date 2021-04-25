using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreTxt = null;
    [SerializeField]
    private Text[] itemCountTxt = null;
    [SerializeField]
    private GameObject gameOverFail = null;
    [SerializeField]
    private GameObject gameOverSuccess = null;
    [SerializeField]
    private Text failScoreTxt = null;
    [SerializeField]
    private Text successScoreTxt = null;
    [SerializeField]
    private Text waitCountTxt = null;
    [SerializeField]
    private Slider timer = null;
    
    [SerializeField]
    private Image[] scoreMGImg = null; // 0: tap_L, 1:slice, 2:tap_s

    [SerializeField]
    private MiniGameCamera camera = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TryGameStart());
    }

    //// Update is called once per frame
    //void Update()
    //{

        
    //}

    // 모치 퇴치 횟수 관련
    public void updateCount(RemovableObj.ObjectType type)
    {
        int now = int.Parse(itemCountTxt[(int)type].text) + 1;
        itemCountTxt[(int)type].text = now.ToString();

    }
    
    public int getCount(RemovableObj.ObjectType type)
    {
        return int.Parse(itemCountTxt[(int)type].text);
    }

    // 타이머 설정
    public void setTimer(float now)
    {
        timer.value = now;
    }

    // 카메라 흔들기
    public void cameraShake()
    {
        camera.cameraShake();
    }

    // 게임 오버
    public void showGameOver(int topScore)
    {
        if (topScore >= 100)
        {
            gameOverSuccess.SetActive(true);
            successScoreTxt.text = topScore.ToString();
        }
        else
        {
            gameOverFail.SetActive(true);
            failScoreTxt.text = topScore.ToString();
        }
    }


    public void updateScore(int nowScore)
    {
        scoreTxt.text = nowScore.ToString();
    }

    // 게임 시작 전 5초 카우트
    IEnumerator TryGameStart()
    {
        float timer = 5f;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            waitCountTxt.text = ((int)timer).ToString();
            yield return null;
        }
        timer = 0f;
        waitCountTxt.text = timer.ToString();

        waitCountTxt.transform.parent.gameObject.SetActive(false);
        MiniGameManager.Instance.startGame();
    }

    // 시작 전 UI 모지 이미지 설정
    public void setUIScoreMG(Object[] MGSprites)
    {
        scoreMGImg[0].sprite = MGSprites[2] as Sprite;
        scoreMGImg[1].sprite = MGSprites[4] as Sprite;
        scoreMGImg[2].sprite = MGSprites[1] as Sprite;
    }
}
