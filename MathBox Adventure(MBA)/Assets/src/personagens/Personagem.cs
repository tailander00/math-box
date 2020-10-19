using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personagem : MonoBehaviour {
	protected int vida;
	protected int força;
	protected float velocidade;
    protected Animator animacao;
	protected int direcao;
}
