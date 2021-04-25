using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class test : MonoBehaviour
{

	public int _exp = 0;
	public Text[] text;

	void Start()
	{
		List<Dictionary<string, object>> data = CSVReader.Read("exp");

		for (var i = 0; i < data.Count; i++)
		{
			text[i].text = "index " + (i).ToString() + " : " + data[i]["EXP"] + " " + data[i]["Bonus"] + " " + data[i]["Text"];
		}

		_exp = (int)data[0]["EXP"];
		Debug.Log(_exp);
	}
}