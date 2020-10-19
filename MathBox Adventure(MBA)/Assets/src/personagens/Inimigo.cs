using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inimigo : Personagem {

    private int x0,cont;

    private void Awake(){
		direcao = 3;
        x0 = 0;
        cont = 0;
        animacao = gameObject.GetComponent<Animator>();
		animacao.SetInteger ("direcao",3);
    }

    void Start () {
       
    }

    private void anda() {
		if (direcao == 3) {
			if (x0 < 10) {
				++x0;
				transform.Translate (new Vector3(0.5f,0));
			} else if (x0 == 10) {
				direcao = 4;
				gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			}
		} else if (direcao == 4) {
			if (x0 > 0) {
				--x0;
				transform.Translate (new Vector3(-0.5f, 0));
			} else if (x0 == 0) {
				direcao = 3;
				gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}

    }
    public void OnCollisionEnter2D(Collision2D outro){
        if (direcao == 4) {
            x0 = 0;
        }else if(direcao == 3) {
            x0 = 10;
        }
    }

    void Update () {
        if(cont % 5 == 0)
            anda();
        cont++;
	}
}
