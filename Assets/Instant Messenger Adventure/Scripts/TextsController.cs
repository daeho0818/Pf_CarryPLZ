using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//classe que controla os textos que aparecem em cena

public class TextsController : MonoBehaviour {

	public static TextsController instance;

    public string nowCSVFileName;
	public TextGroup currentMessageGroup; 
	public GameObject textContentPrefab; 
	public GameObject answerContentPrefab; 
	public Transform messagesContent;

    public GameObject startContentPrefab;

    public GameObject minigameButton;

    public Text[] answerTexts = new Text[2];
    public List<Answers> answerList = new List<Answers>();

    public Text typingText;
    [SerializeField]
    private Text stopText = null;

    [SerializeField]
    private string[] userName = null;
    [SerializeField]
    private Sprite[] userProfileImages = null;

    private Dictionary<string, Sprite> userInfo = new Dictionary<string, Sprite>();
    [SerializeField]
    private int num = 1; // 공통 대본 번호
    private bool end = false;
    private bool stop = false;


    [SerializeField]
    private AudioSource audioSource = null; // 카톡 답장올 때 소리

    private void Awake()
	{
		instance = this; //no Awake, transforma a instancia nesse objeto
	}

	// Use this for initialization
	void Start () {

        setUserInfo();
        nowCSVFileName = getCSVFileName();

        StartCoroutine(SendingMessages()); 
	}

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            end = false;
            nowCSVFileName = getCSVFileName();
            num++;
            StartCoroutine(SendingMessages());
        }
    }

    private void setUserInfo()
    {
        for (int i = 0; i < userName.Length && i < userProfileImages.Length; i++)
        {
            userInfo.Add(userName[i], userProfileImages[i]);
        }
    }

    private string getDayToString()
    {
        string dayString = "";
        switch (DayManager.dayNum % 7)
        {
            case 1: // 화
                dayString += "화";
                break;
            case 3: // 목
                dayString += "목";
                break;
            case 5: // 토
                dayString += "토";
                break;
            default: // 예외
                dayString += "화";
                break;
        }
        return dayString;
    }

    private string getCSVFileName()
    {
        string name = getDayToString() + "_공통" + num.ToString();
        return name;
    }

	IEnumerator SendingMessages() 
	{
        List<Dictionary<string, object>> chatData = CSVReader.Read(nowCSVFileName);
        Debug.Log("load: " + nowCSVFileName);
        for (int i = 0; i < chatData.Count; i++)
        {
            string dataName = chatData[i]["name"].ToString();
            string dataScript = chatData[i]["script"].ToString();
            float waitTime = int.Parse(chatData[i]["time"].ToString());
            Sprite image = null;
            yield return new WaitForSeconds(waitTime);
            typingText.text = "typing...";
            yield return new WaitForSeconds(waitTime);
            typingText.text = "Online";

            // 일시정지 대기
            while (stop)
                yield return new WaitForSeconds(0.5f);

            //말풍선 생성
            GameObject newTextContent;
            if (dataName == "상황")
                newTextContent = Instantiate(startContentPrefab, messagesContent);
            else if (dataName == "주인공")
                newTextContent = Instantiate(answerContentPrefab, messagesContent);
            else
            {
                newTextContent = Instantiate(textContentPrefab, messagesContent);
                audioSource.Play();
            }

            newTextContent.transform.SetSiblingIndex(0);
            if (userInfo.ContainsKey(dataName))
                image = userInfo[dataName];
            newTextContent.GetComponent<Chat>().setChat(dataName, image, dataScript);
            newTextContent.transform.localScale = new Vector3(1, -1, 1);
            

        }

        chatData.Clear();
        
        chatData = CSVReader.Read("선택지");

        for (int i = 0; i < chatData.Count; i++)
        {
            if (chatData[i]["day"].ToString() == getDayToString() + num.ToString())
            {
                Answers answer = new Answers();
                answer.text = chatData[i]["script"].ToString();
                answer.fileName = chatData[i]["next"].ToString();
                answerList.Add(answer);
            }
        }

        yield return new WaitForSeconds(1);
        if (answerList.Count == 0)
        {
            Debug.Log("check: " + getCSVFileName());
            // 다음 공통대본 파일이 존재하지 않으면 미니게임 버튼 표시
            if (num == 1 || !Resources.Load(getCSVFileName()))
                minigameButton.SetActive(true);
            else
                end = true;
            yield break;
        }
            

        for (int i = 0; i < answerList.Count; i++)
        {
            answerTexts[i].text = answerList[i].text;
            answerTexts[i].transform.parent.gameObject.SetActive(true);
        }
	}

    // 선택지 버튼
    public void SetNextGroup(int index) 
	{
        num++;
        nowCSVFileName = answerList[index].fileName;
        
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].transform.parent.gameObject.SetActive(false);
        }
        answerList.Clear();
        StartCoroutine(SendingMessages()); 
    }

    // 일시정지 버튼
    public void StopButton()
    {
        stop = !stop;
        if (stopText == null)
            return;

        if (stop)
            stopText.text = "계속\n하기";
        else
            stopText.text = "일시\n정지";
    }
}
