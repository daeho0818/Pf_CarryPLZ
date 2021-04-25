using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class Texts{
    public string name;
	public string text; //texto da mensagem
	public float waitTime = 1; //tempo que espera antes de digitar
	public float typingTime = 2; //tempo para ela ser digitada
}
