using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System; 

public class Inicio2 : MonoBehaviour {
	private Stream stream;
	public GameObject inicio3;
	public GameObject configuracao;

	void Start () {
		inicio3.SetActive(false);
		configuracao.SetActive(false);

		int fase = Int32.Parse (Arquivo.getFase());

		if(fase == 1){
			gameObject.GetComponentsInChildren<Button>()[1].interactable = false;
		}
	}

	public void comacar() {
		Arquivo.setFase("1");
		Arquivo.salva();
		inicio3.SetActive(true);
	}

	public void continuar(){
		inicio3.SetActive(true);
	}
	public void config(){
		configuracao.SetActive(true);
	}

	public void sair(){
		Application.Quit();
	}

}
