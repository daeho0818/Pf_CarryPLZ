using UnityEngine;

[CreateAssetMenu]
public class TextGroup : ScriptableObject {
	public Texts[] texts; //textos das mensagens
	public Answers[] answers = new Answers[2]; //opções de resposta
}
