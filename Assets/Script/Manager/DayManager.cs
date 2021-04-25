using UnityEngine;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    static public int day = 1;
    static public int dayNum = 0;


    void Start(){
        dayNum = dayNum % 7;
        Debug.Log("DayNum : " + dayNum);
    }

    void Update()
    {
        //dayNum = dayNum % 7;
        Debug.Log("day : " + day);
    }
    public void dayPlus()
    {
        day++;
        dayNum++;
        UIManager.time = 0.05f;
    }
}