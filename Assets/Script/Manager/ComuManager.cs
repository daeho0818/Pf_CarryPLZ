using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComuManager : MonoBehaviour
{
    [SerializeField] private Text[] ChoiceRoad;
    [Space (10f)]
    [SerializeField] private GameObject MngmBtn;
    
    public GameObject[] Comunication;
    public RectTransform[] ComuUI;
    public GameObject Choice;

    static public int GoodGauge;
    static public float DeleteSpeed;
    public bool[] _flag;
    private int a, b, c;
    private void Awake()
    {
        _flag[0] = true;
        DeleteSpeed = 1;
    }
    void Start()
    {
        StartCoroutine("ComuSystem");
    }
   
    public void choice1()
    {
        Choice.SetActive(false);
        GoodGauge = 1;
        StartCoroutine("ComuSystem2");
    }
    public void choice2()
    {
        Choice.SetActive(false);
        GoodGauge = -1;
        StartCoroutine("ComuSystem3");
    }
    IEnumerator ComuSystem()
    {
        Comunication[0].SetActive(_flag[0]);
        yield return new WaitForSeconds(DeleteSpeed);
        Comunication[1].SetActive(_flag[0]);
        yield return new WaitForSeconds(DeleteSpeed);
        Comunication[2].SetActive(_flag[0]);
        yield return new WaitForSeconds(DeleteSpeed);
        Comunication[3].SetActive(_flag[0]);
        yield return new WaitForSeconds(DeleteSpeed);
        Comunication[4].SetActive(_flag[0]);
        yield return new WaitForSeconds(DeleteSpeed);
        Choice.SetActive(_flag[0]);
        _flag[1] = true;
        _flag[2] = true;
        ChoiceRoad[0].text = "회의 시작할게요";
        ChoiceRoad[1].text = "(그냥 잠수탄다.)";
    }
    private void ChatToUp()
    {
        Comunication[a].SetActive(false);
        for (int i = b; i < c; i++)
        {
            ComuUI[i].position = new Vector3(ComuUI[i].position.x, ComuUI[i].position.y + 1.2f, ComuUI[i].position.z);
        }
    }
    IEnumerator ComuSystem2()
    {
        a = 0; b = 1; c = 5;
        ChatToUp();
        Comunication[5].SetActive(_flag[1]);
        yield return new WaitForSeconds(DeleteSpeed);
        a = 1; b = 2; c = 6;
        ChatToUp();
        Comunication[6].SetActive(_flag[1]);
        yield return new WaitForSeconds(DeleteSpeed);
        a = 2; b = 3; c = 7;
        ChatToUp();
        Comunication[7].SetActive(_flag[1]);
        yield return new WaitForSeconds(DeleteSpeed);
        a = 3; b = 4; c = 8;
        ChatToUp();
        Comunication[8].SetActive(_flag[1]);
        yield return new WaitForSeconds(DeleteSpeed);
        a = 4; b = 5; c = 9;
        ChatToUp();
        Comunication[9].SetActive(_flag[1]); 
        yield return new WaitForSeconds(DeleteSpeed);
        MngmButnUp();
    }
    IEnumerator ComuSystem3()
    {
        a = 0; b = 1; c = 5;
        ChatToUp();
        Comunication[10].SetActive(_flag[2]);
        yield return new WaitForSeconds(DeleteSpeed);
        a = 1; b = 2; c = 11;
        ChatToUp();
        Comunication[11].SetActive(_flag[2]);
        yield return new WaitForSeconds(DeleteSpeed);
        MngmButnUp();
    }
    private void MngmButnUp()
    {
        MngmBtn.SetActive(true);
    }
}