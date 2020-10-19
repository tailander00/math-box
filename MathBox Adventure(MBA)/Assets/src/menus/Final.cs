using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

	private bool pausado;

	void Start(){
		pausado = false;
	}

	void Update(){
		
	}

	public void pausar(){
		if (!pausado){
			Time.timeScale = 0;
			pausado = true;

		}else {
			Time.timeScale = 1;
			pausado = false;
		}
	}

	public void sair(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("inicio");
	}
}
