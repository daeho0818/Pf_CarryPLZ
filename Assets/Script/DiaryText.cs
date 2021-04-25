using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryText : MonoBehaviour
{
    public Text text;
    public Text dayText;
    void Update()
    {
        if (DayManager.dayNum % 7 == 0)
        {
        }
        else if (DayManager.dayNum % 7 == 1)
        {
        }
        else if (DayManager.dayNum % 7 == 2)
        {
        }
        else if (DayManager.dayNum % 7 == 3)
        {
        }
        else if (DayManager.dayNum % 7 == 4)
        {
        }
        else if (DayManager.dayNum % 7 == 5)
        {
        }
        else if (DayManager.dayNum % 7 == 6)
        {
        }
    }
    void Start()
    {
        dayText.text = "4월 ";
        if (DayManager.dayNum == 0)
        {
            dayText.text += DayManager.day + "일 월요일";
            text.text = "꿈에 나온 조원들의 이름과 생김새... "+"모두가 똑같은 사람들과 한 조가 되었다. "+
            "게다가 내가 조장이라는 점도 똑같았다. "+"그 꿈이 예지몽이었던 걸까?";
        }
        else if (DayManager.dayNum == 1)
        {
            dayText.text += DayManager.day + "일 화요일";
            text.text = "오늘 아침 꿈에는 '학점요정'이라고 말하던 이상한 게 나오지 않았다. 아무래도 저번에 꾼 꿈은 그냥 개꿈이었던 것 같다.";
        }
        else if (DayManager.dayNum == 2)
        {
            dayText.text += DayManager.day + "일 수요일";
            if (ScoreManager.scoreArr[0]){ // 성공
                text.text = "믿기 힘들지만, 모지 퇴치가 정말 효과가 있는 것 같다. 허세와 가오 빼면 시체인 사람이 사과를 하다니.."+
                " 하지만 거리를 두고 싶었기에 사과를 받아주진 않았다.";

            } else{ // 실패
                text.text = "평소와 다를 바 없는 선배였다. 모지를 충분히 퇴치하지 못 한 것 같다."
                +" 제멋대로 굴어서 팀플 분위기만 망치고, 진짜 짜증나. 연락도 안 받는 걸 보니 계속 잠수 탈 생각인가 보다.";
            }

        }
        else if (DayManager.dayNum == 3)
        {
            dayText.text += DayManager.day + "일 목요일";
            text.text = "자정이 넘도록 기다렸지만 자료가 오지 않았다... 제가 만약 고혈압으로 죽으면 1팀 조원들이 범인입니다.\n다 잡아가주세요.";
        }
        else if (DayManager.dayNum == 4)
        {
            dayText.text += DayManager.day + "일 금요일";
            if (ScoreManager.scoreArr[1]){ // 성공
                text.text = "모지 퇴치의 영향으로 나에게 사과한 거겠지만 자료도 정말 잘 준비해 왔고,"+
                " 쭈뼛거리면서 저녁 약속 잡는 게 귀여워서 그냥 받아줬다. 반수 준비 정말 잘 됐으면 좋겠다.";
        
            } else{ // 실패
                text.text = "김재혁을 말렸어야 했는데.. 김재혁이 어떤 사람인지 알고도 방치한 내 불찰이다."+
                " 그 와중에 세민이는 눈치 없이 회식을 가자 하니 속이 터진다. 나만 학점에 진심이지ㅠㅠ";
            }
        }
        else if (DayManager.dayNum == 5)
        {
            dayText.text += DayManager.day + "일 토요일";
            text.text = "미치겠네.";
        }
        else if (DayManager.dayNum == 6)
        {
            dayText.text += DayManager.day + "일 일요일";
            if (ScoreManager.scoreArr[2]){ // 성공
                text.text = "모지 퇴치가 성공적이었던 것 같다. 말도 안 되는 오해가 풀리고 나니 정말 일사천리로 조별 과제가 끝났다."+
                " 퇴치를 못했다면 안세민이 김재혁을 뛰어넘었을지도 모르겠다.";
        
            } else{ // 실패
                text.text = "김재혁 선배보다 꼴 보기 싫은 사람이 생길 줄은 몰랐다."
                +" 안세민이랑은 두 번 다시 마주칠 일 없었으면 좋겠다.";
            }
        }
    }
}
