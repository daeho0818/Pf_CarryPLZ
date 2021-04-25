using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Answers{

	public string text; //texto da resposta
	public TextGroup nextGroup; //próximo grupo que carrega caso ela seja selecionada
    public string fileName;
    public string nextFileName;
}
