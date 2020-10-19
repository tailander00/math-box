using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;

public class inicio3 : MonoBehaviour {
	private int faseAtual;
	private Button[] botoes;

	void Start () {
		faseAtual = Int32.Parse (Arquivo.getFase());
		botoes = gameObject.GetComponentsInChildren<Button> ();
		for (int i = 0; i < faseAtual; i++) {
			botoes [i].interactable = true;
		}
		for (int i = faseAtual; i < 6; i++) {
			botoes [i].interactable = false;
		}
	}

	public void onClick(string fase) {
		SceneManager.LoadScene(fase);
	}

	public void voltar(){
		gameObject.SetActive(false);
	}
}
