using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    //싱글톤
    private static MiniGameManager instance;
    public static MiniGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<MiniGameManager>();
                if (obj == null)
                {
                    obj = new GameObject("MiniGameManager").AddComponent<MiniGameManager>();
                }
                instance = obj;
            }
            return instance;
        }

        private set
        {
            Instance = value;
        }
    }

    [SerializeField]
    protected MiniGameUI UI = null;

    [SerializeField]
    protected GameObject[] startPos = null; // 아이템 던지는 위치
    [SerializeField]
    protected GameObject Items = null; // 던져진 아이템들
    [SerializeField]
    protected GameObject[] MoziPrefabs = null; // 0: tap_L, 1:slice, 2:tap_s, 3:boom
    [SerializeField]
    protected GameObject[] ItemPrefabs = null;
    [SerializeField]
    private int[] itemCount = { 0, 0, 0 };
    [SerializeField]
    private int max = 3;

    protected float itemWaitTime = 0f; // 다음 아이템 던지기까지 남은 시간
    private float gameTime = 60f;

    private int totalScore = 0; // 총합 점수
    private int topScore = 0; // 최고점수

    private int life = 3;

    private bool gameOver = false;
    [SerializeField]
    protected bool start = false;
    [SerializeField]
    private bool itemUsed = false;


    [SerializeField]
    protected float objSize = 1f; // obj 생성 시 크기

    // Start is called before the first frame update
    void Start()
    {
        setMG();
        getSizeItem(1, 10); // 젓 시작 20초 동안은 아이템 나오지 않게
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime < 0f)
        {
            //게임 시간 끝나면 game over
            UI.showGameOver(topScore);
            gameOver = true;
        }

        if (!gameOver && start)
        {
            gameTime -= Time.deltaTime;
            UI.setTimer(gameTime);
            throwItem();
        }

        if (gameOver)
        {
            // 게임 성공여부 저장, 스토리 분기점에 사용(지현)
            getScoreArr();

            // 결과화면. 터치하면 채팅으로 이동
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Diary");
                UIManager.time = 0;
                boolSaver.bDiary = true;
                boolSaver.bRealTalk = false;
                boolSaver.bMiniGame = false;
            }
        }
    }

    private void setMG()
    {
        Sprite[] MGSprite = new Sprite[5]; // 0:tap_L_1, 1:tap_L_2, 2:slice, 3:tap_s, 4:boom
        string path = "Mozi/";

        switch (DayManager.dayNum % 7)
        {
            case 1: // 화
                path += "JH";
                break;
            case 3: // 목
                path += "MY";
                break;
            case 5: // 토
                path += "SM";
                break;
            default: // 예외
                path += "Default";
                break;
        }

        path += "_mozi";

        // load sprite
        Object[] MGSprites = Resources.LoadAll(path);

        // set UI
        UI.setUIScoreMG(MGSprites);

        // set MG Prefep (0: tap_L, 1:slice, 2:tap_s, 3:boom)
        MoziPrefabs[0].GetComponent<SpriteRenderer>().sprite = MGSprites[2] as Sprite;
        MoziPrefabs[1].GetComponent<SpriteRenderer>().sprite = MGSprites[4] as Sprite;
        MoziPrefabs[2].GetComponent<SpriteRenderer>().sprite = MGSprites[1] as Sprite;
        MoziPrefabs[3].GetComponent<SpriteRenderer>().sprite = MGSprites[5] as Sprite;
    }

    public void throwItem()
    {
        itemWaitTime -= Time.deltaTime;

        if (itemWaitTime < 0f && Items.transform.childCount < max)
        {
            int startIndex = Random.Range(0, startPos.Length); // 시작위치 설정
            //int itemIndex = getItemIndex(); // 던질 아이템 결정

            // 던질 아이템 생성
            GameObject instance = getThrowObj(startIndex);// Instantiate(ItemPrefabs[itemIndex], startPos[startIndex].transform);
            instance.transform.parent = Items.transform;
            instance.transform.localScale *= objSize;

            itemWaitTime = Random.Range(1, 3);
        }
    }

    private GameObject getThrowObj(int startIndex)
    {
        int idx = 0;
        if (itemUsed)
        {
            // 아이템 효과가 나타나는 중이면 모지만 생성
            idx = Random.Range(0, MoziPrefabs.Length);
            return Instantiate(MoziPrefabs[idx], startPos[startIndex].transform);
        }

        if (Random.Range(0, 1) == 0) // 50퍼 확률로 아이템, 모지 생성
        {
            //먼저 아이템 생성 시도
            idx = Random.Range(0, ItemPrefabs.Length);
            if(itemCount[idx] < 2)
            {
                itemCount[idx]++;
                return Instantiate(ItemPrefabs[idx], startPos[startIndex].transform);
            }
        }

        //아이템 생성에 실패하면 모지 생성
        idx = Random.Range(0, MoziPrefabs.Length);
        return Instantiate(MoziPrefabs[idx], startPos[startIndex].transform);
    }

    public void lossLife()
    {
        if (gameOver)
        {
            return;
        }

        // 게임 오버
        if (--life <= 0)
        {
            UI.showGameOver(topScore);
            gameOver = true;
            life = 0;
        }

        //UI 업데이트
        UI.updateScore(life);
    }

    public void addScore(int score, RemovableObj.ObjectType type)
    {
        if (gameOver)
        {
            return;
        }

        totalScore += score;

        // 최고점수 교체 
        topScore = totalScore > topScore ? totalScore : topScore;

        //출현 개수 조정
        max = topScore / 7;
        if(max > 5)
        {
            max = 5;
        }

        //UI 업데이트
        UI.updateCount(type);
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void startGame()
    {
        start = true;
    }

    public void getTimerItem(float time)
    {
        gameTime += time;
        getSizeItem(1, 10); //타이머 아이템 흭득 후 10초간 아이템이 나오지 않도록
    }

    public void getSizeItem(float size, float time)
    {
        StartCoroutine(setObjSize(size, time));
    }

    public void getScoreArr(){ //3판의 미니게임 성공여부 저장(지현)

        int day = DayManager.dayNum%7;

        if(day == 1){ //화
            ScoreManager.scoreArr[0] = (topScore >= 100) ? true : false;

        } else if(day == 3){ //목
            ScoreManager.scoreArr[1] = (topScore >= 100) ? true : false;
            
        } else if(day == 5){ //토
            ScoreManager.scoreArr[2] = (topScore >= 100) ? true : false;

        } else { //예외처리
            Debug.Log("예외");
            Debug.Log("날짜:"+DayManager.dayNum);
        }
    }

    // 크기변경 아이템 사용
    IEnumerator setObjSize(float size, float time)
    {
        itemUsed = true;
        objSize = size;
        yield return new WaitForSeconds(time);
        objSize = 1f;
        itemUsed = false;
    }

    // 카메라 흔들기
    public void cameraShake()
    {
        UI.cameraShake();
    }
}
