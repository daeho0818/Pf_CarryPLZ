using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndingManager : MonoBehaviour
{

    public GameObject[] EndFlow = new GameObject[8];

    private bool[] endCase = ScoreManager.scoreArr;
    // endCase[0] = 재혁 모지퇴치
    // endCase[1] = 민영 모지퇴치
    // endCase[2] = 세민 모지퇴치

    // Start is called before the first frame update
    void Start()
    {
        EndingCase();
    }

    public void EndingCase(){

        if(endCase[0] && endCase[1] && endCase[2]){
            //A+
            EndFlow[0].SetActive(true);

        } else if(!endCase[0] && endCase[1] && endCase[2]){
            //A
            EndFlow[1].SetActive(true);

        } else if(!endCase[2] && endCase[1] && !endCase[2]){
            //B+
            EndFlow[2].SetActive(true);

        }else if(endCase[0] && endCase[1] && !endCase[2]){
            //B
            EndFlow[3].SetActive(true);

        } else if(endCase[0] && !endCase[1] && endCase[2]){
            //C+
            EndFlow[4].SetActive(true);

        } else if(endCase[0] && !endCase[1] && !endCase[2]){
            //C
            EndFlow[5].SetActive(true);

        } else if(!endCase[2] && !endCase[1] && endCase[2]){
            //D
            EndFlow[6].SetActive(true);

        } else if(!endCase[2] && !endCase[1] && !endCase[2]){
            //F
            EndFlow[7].SetActive(true);
            
        } else{
            Debug.Log("예외");
            EndFlow[7].SetActive(true);
        }
    }

}
