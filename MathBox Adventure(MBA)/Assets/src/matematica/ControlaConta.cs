using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ControlaConta : MonoBehaviour {

	private int resposta;
	public int valor;
    private InputField input;
    private bool certo;
	private int []valores;
	public AudioClip errado;
	private AudioSource src;

    // Use this for initialization
    void Start () {
    	src = gameObject.GetComponent<AudioSource>();
		src.loop = false;
		valores = new int[6];
		certo = false;
		input = gameObject.GetComponentInChildren<InputField> ();
		gameObject.GetComponentInChildren<Text> ().text = Convert.ToString(valor) + " =";
    }

	public void altera(int alteracao,int i){
		int tipo;
		if (i == 3) {
			tipo = 5;
		} else if (i == 4) {
			tipo = 7;
		} else if (i == 5) {
			tipo = 10;
		} else {
			tipo = i+1;
		}

		valores [i] += alteracao; 
		resposta += alteracao*tipo;

		input.text = " ";

		for(i=0;i<6;i++){
			if(valores [i] != 0){
				
				if (i == 3) {
					tipo = 5;
				} else if (i == 4) {
					tipo = 7;
				} else if (i == 5) {
					tipo = 10;
				} else {
					tipo = i+1;
				}
					
				if(input.text != " ")
					input.text += " + ";
				if (valores [i] == 1) {
					input.text += Convert.ToString(tipo);
				} else {
					if(Arquivo.getParada() == "fase1" || Arquivo.getParada() == "fase2" || Arquivo.getParada() == "fase3"){
						for(int x=0;x<valores [i];x++){
							input.text += Convert.ToString(tipo);
							if(x != valores [i]-1)
								input.text += " + ";
						}
					}else{
						input.text += Convert.ToString(valores [i]) + "X" + Convert.ToString(tipo);
					}
				}

			}
					
		}
	}

	public void setValor(int x){
		valor = x;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			sair();
		}
	}

	public void responder(){
		if (valor == resposta) {
			for (int i = 0; i < 6; i++) {
				Jogador.jogador.alteraBolinhas (-valores[i],i);
			}
			certo = true;
		}else{
			src.clip = errado;
			src.Play();
		} 
	}

	public bool getCerto(){
		return certo;
	}

	public void sair(){
		Time.timeScale = 1;
		Destroy (this.gameObject); 
	}
}

