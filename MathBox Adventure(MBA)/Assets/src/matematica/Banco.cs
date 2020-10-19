using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Banco : MonoBehaviour {
	private Text[] numeros;
	private int[] originais;
	// Use this for initialization
	void Start () {
		numeros = GetComponentsInChildren<Text>();
		originais = new int[6];

	}
	
	// Update is called once per frame
	void Update () {
		originais = Jogador.jogador.getBolinhas ();
		for (int i = 0; i < 6; i++) {
			numeros [i*2].text = Convert.ToString (originais [i]); 
		}
	}
}
