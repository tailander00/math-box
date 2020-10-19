using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuracoes : MonoBehaviour {

	private Slider musica;
	private Slider efeitos;

	void Start () {
		musica = gameObject.GetComponentsInChildren<Slider>()[0];
		efeitos = gameObject.GetComponentsInChildren<Slider>()[1];

		musica.value = Arquivo.getVolumeMusica();
		efeitos.value = Arquivo.getVolumeEfeitos();
	}
	
	public void sair(){
		gameObject.SetActive(false);
	}

	public void salvar(){
		Arquivo.setVolumeMusica(musica.value);
		Arquivo.setVolumeEfeitos(efeitos.value);
		Arquivo.salva();
		sair();
	}

	void Update () {
		
	}
}
