using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject opcoes,instrucoes;

	// Use this for initialization
	void Start () {
		opcoes.SetActive(false);
		instrucoes.SetActive(false);
	}
	
	public void config(){
		opcoes.SetActive(true);
	}

	public void help(){
		instrucoes.SetActive(true);
	}

	void Update () {
		
	}
}
