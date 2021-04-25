using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    public GameObject[] DayFlow = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("날짜:"+DayManager.dayNum);
        for (int i=0; i<3; i++){
            Debug.Log(i+"번째 미니게임 점수: "+ScoreManager.scoreArr[i]);
        }

        if(DayManager.dayNum%7 == 0){ // 월
            DayFlow[1].SetActive(true);

        } else if(DayManager.dayNum%7 == 2){ //수

            if(ScoreManager.scoreArr[0]){ // 성공
                DayFlow[2].SetActive(true);
            } else{ //실패
                DayFlow[3].SetActive(true);
            }
            
        } else if(DayManager.dayNum%7 == 4){ //금

            if(ScoreManager.scoreArr[1]){ // 성공
                DayFlow[4].SetActive(true);
            } else{ //실패
                DayFlow[5].SetActive(true);
            }

        } else if(DayManager.dayNum%7 == 6){ //일

            if(ScoreManager.scoreArr[2]){ // 성공
                DayFlow[6].SetActive(true);
            } else{ //실패
                DayFlow[7].SetActive(true);
            }

        } else { //예외처리
            Debug.Log("예외");
            Debug.Log("날짜:"+DayManager.dayNum);
            DayFlow[0].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("날짜:"+DayManager.dayNum);
    }
}
