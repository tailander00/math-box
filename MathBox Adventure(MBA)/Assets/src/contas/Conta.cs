using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Conta : MonoBehaviour {
	private System.Random rand;
	private int primeiroTermo;
	private int segundoTermo;
	public int resultado;
	public Text texto;
	public GameObject painel;
	public char tipo;

	private void geraSoma(){
		primeiroTermo = rand.Next(2,11);
		segundoTermo = rand.Next(2,11);
		resultado = primeiroTermo + segundoTermo;
	}

	private void geraMultiplicacao(){
		primeiroTermo = rand.Next(2,11);
		segundoTermo = rand.Next(2,11);
		resultado = primeiroTermo * segundoTermo;
	}

	private void geraDivisao(){
		segundoTermo = rand.Next(2,11);
		resultado = rand.Next(2,11);
		primeiroTermo = segundoTermo * resultado;
	}

	private void geraSubtracao(){
		primeiroTermo = rand.Next(2,11);
		do {
			segundoTermo = rand.Next(2,11);
		} while(segundoTermo > primeiroTermo);
		resultado = primeiroTermo + segundoTermo;
	}

	void Start () {
		rand = painel.GetComponent<Rand> ().rand;
			switch(tipo){
			case '+':
				geraSoma ();
				break;
			case '-':
				geraSubtracao ();
				break;
			case '*':
				geraMultiplicacao ();
				break;
			case '/':
				geraDivisao ();
				break;
			}
			texto.text = Convert.ToString(primeiroTermo) + " " + tipo + " " + Convert.ToString(segundoTermo) + " = ";
	}

	void Update () {
		
	}
}
