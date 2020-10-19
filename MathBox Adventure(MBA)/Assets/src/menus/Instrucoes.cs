using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrucoes : MonoBehaviour {

	public Sprite[] imagens;
	public AudioClip[] audios;
	private AudioSource src; 
	private int i;

	void Start () {
		src = gameObject.GetComponent<AudioSource>();
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void vai(){
		if(i < 4){
			++i;
			GetComponentInChildren<Image>().sprite = imagens[i];
			src.clip = audios[i];
			src.Play();
		}else if(i == 4){
			gameObject.SetActive(false);
			i = 0;
			GetComponentInChildren<Image>().sprite = imagens[i];
			src.clip = audios[i];
		}
	}

	public void volta(){
		if(i > 0){
			--i;
			GetComponentInChildren<Image>().sprite = imagens[i];
			src.clip = audios[i];
			src.Play();
		}else if(i == 0){
			gameObject.SetActive(false);
		}
	}
}
