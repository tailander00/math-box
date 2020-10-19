using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Resposta : MonoBehaviour {
    public static Resposta resposta;
	public GameObject[] contas;
    private bool resultado;

	public void OnClick(){
		foreach (GameObject conta in contas) {
			if(conta.GetComponentInChildren<Conta>().resultado != Int32.Parse(conta.GetComponentInChildren<InputField>().text)){
				Debug.Log("errado");
				resultado = false;
                return;
			}
		}
		Debug.Log("certo");
		resultado = true;
	}

    /*
    public void Awake(){
        resposta = this;
        DontDestroyOnLoad(resposta);
    }
    */
}
