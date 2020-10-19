using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quantidade : MonoBehaviour {

	private int valor;
	public Text text;
	public GameObject pai;
	public int i;
	// Use this for initialization
	void Start () {
		valor = 0;
		text.text = Convert.ToString (valor);
	}

	public void altera(int alteracao){
		if (valor + alteracao <= Jogador.jogador.getBolinhas () [i] && valor + alteracao >= 0) {
			pai.GetComponent<ControlaConta> ().altera (alteracao,i);
			valor += alteracao;
			text.text = Convert.ToString (valor);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
