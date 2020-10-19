using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	private int fase;

	void Start () {
	}

	public void continuar() {
		SceneManager.LoadScene(Arquivo.getParada());
	}

	public void menu() {
		SceneManager.LoadScene("inicio");
	}
}
