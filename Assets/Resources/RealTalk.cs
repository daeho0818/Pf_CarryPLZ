using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTalk : MonoBehaviour
{
    //public Text text;
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("3_수_성공");
        for (var i = 0; i < data.Count; i++)
        {
            if(data[i].ContainsKey("script"))
            {
                Debug.Log("ㅁ");
            }
            Debug.Log("index " + (i).ToString() + " " + data[i][name] + ": " + data[i]["script"]);
        }
        //if (DayManager.dayNum == 3)
        //StartCoroutine(WendsDayTalk());
    }
}