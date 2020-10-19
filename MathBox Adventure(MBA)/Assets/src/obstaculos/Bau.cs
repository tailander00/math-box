using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System; 
using UnityEngine.UI;

public class Bau : MonoBehaviour {
	public int prox;
    public Canvas canvas;
    public AudioClip open;
    public GameObject parabens;
    private GameObject tela;
	private AudioSource src;
    private String carregar;
    

    public void Awake(){
        gameObject.GetComponent<Animator>().speed = 0;
    }

    void Start () {
		src = gameObject.GetComponent<AudioSource>();
		src.loop = false;
	}

    public void OnCollisionEnter2D(Collision2D outro){
        if (outro.gameObject.CompareTag("jogador") && Jogador.jogador.getKeys() > 0) {
        	src.clip = open;
			src.Play();
            Jogador.jogador.alteraChaves(-1);
            gameObject.GetComponent<Animator>().speed = 1;

			Arquivo.setFase(Convert.ToString(prox));
            Arquivo.salva();
            Time.timeScale = 0;
            tela = Instantiate(parabens, canvas.transform.position, Quaternion.identity);
            tela.GetComponentInChildren<Button>().onClick.AddListener(onClick);
            
            if(prox < 7){
                carregar = "fase"+Convert.ToString(prox);
            }else{
                carregar = "final";
                tela.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Terminar";
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void onClick(){
        Time.timeScale = 1;
        SceneManager.LoadScene (carregar);
    }
}
