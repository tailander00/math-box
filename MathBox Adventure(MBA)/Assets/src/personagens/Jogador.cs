using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Jogador : Personagem {
	 
	
	private AudioSource src;
    private bool pausado;
	private float[] axis;
	private int[] bolinhas;
	private int chaves; 
    private int tomandoDano;
    private bool teclado;
    public static Jogador jogador;
	public AudioClip coin,over,hit;
    public GameObject menu;
    public Text[] textBolinhas;
    public Canvas status;

	void Start () {
		menu.SetActive(false);
		src = gameObject.GetComponent<AudioSource>();
		src.loop = false;
        tomandoDano = 150;
        animacao = gameObject.GetComponent<Animator>();
        animacao.speed = 0;
		chaves = 0;
		jogador = this;
        pausado = false;
		axis = new float[3];
		bolinhas = new int[6];
		for (int i = 0; i < 6; i++) {
			bolinhas [i] = 0;
			textBolinhas [i].text = "0";
		}
		textBolinhas [6].text = Convert.ToString (chaves);
		velocidade = 4;
		vida = 50;
	}

	public void controlaStatus(){
        tomandoDano++;
        if (tomandoDano < 150 && tomandoDano % 3 == 0) {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;

        }else {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
        }
        status.GetComponentInChildren<Slider>().value = vida;
		status.GetComponentInChildren<Slider>().GetComponentInChildren<Text>().text = Convert.ToString (vida) + " / 50" ;

		src.volume = Arquivo.getVolumeEfeitos();
	}

	public void anda(){

		if (axis [0] != 0 || axis [1] != 0) {
            animacao.speed = 1;
            if(Math.Pow(axis[1],2) > Math.Pow(axis[0],2)){
            	if (axis[1] > 0){
	                direcao = 1;
	            }else if (axis[1] < 0) {
	                direcao = 2;
	            }
            }else if (axis[0] != 0){
                direcao = 3;
                if (axis[0] < 0){
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else{
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            
		}else{
            direcao = 0;
            animacao.speed = 0;
        }

        animacao.SetInteger ("direcao", direcao);
		axis [0] *= velocidade;
		axis [1] *= velocidade;
		transform.Translate (new Vector3 (axis[0] * Time.deltaTime , axis[1] * Time.deltaTime , 0));
	}

	public void pause(){
		if (!pausado){
			Time.timeScale = 0;
			pausado = true;
			menu.SetActive(true);

		}else {
			Time.timeScale = 1;
			pausado = false;
			menu.SetActive(false);
		}
	}

	public void fechar(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("inicio");
	}

    public void pausa() {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)) {
           	pause ();   
		}
    }

    public void OnCollisionEnter2D(Collision2D outro){
		for (int i = 0; i < 6; i++) {
			if (outro.gameObject.CompareTag ("bola"+Convert.ToString(i))) {
				DestroyObject(outro.gameObject);
				++bolinhas [i];
				textBolinhas [i].text = Convert.ToString (bolinhas[i]);
				src.clip = coin;
				src.Play();
			}
		}
		if (outro.gameObject.CompareTag ("chave")) {
			DestroyObject(outro.gameObject);
			++chaves;
			textBolinhas [6].text = Convert.ToString (chaves);
			src.clip = coin;
			src.Play();
		}
        if (outro.gameObject.CompareTag("inimigo") &&  tomandoDano >= 30) {
            vida -= 10;
            src.clip = hit;
			src.Play();
			if (vida <= 0) {
				src.clip = over;
				src.Play();
				SceneManager.LoadScene ("gameOver");
			}
            tomandoDano = 0;
        }
    }

	public int[] getBolinhas(){
		return bolinhas;
	}

    public void alteraBolinhas(int alteracao, int alterado) {
        bolinhas[alterado] += alteracao;
        textBolinhas[alterado].text = Convert.ToString(bolinhas[alterado]);
    }

	public void alteraChaves(int alteracao){
		chaves += alteracao;
		textBolinhas [6].text = Convert.ToString (chaves);
	}

	public void setAxis(float x,float y){
		axis[0] = x;
		axis[1] = y;
		anda();
	}

    public int getKeys() {
        return chaves;
    } 

    void Update () {
    	if(Input.GetAxis ("Horizontal") != 0  || Input.GetAxis("Vertical") != 0 ){
    		setAxis(Input.GetAxis ("Horizontal"),Input.GetAxis("Vertical"));
    		teclado = true;
    	}else if(teclado){
    		teclado = false;
    		setAxis(0,0);
    	}
        controlaStatus();
        pausa();
	}

}
