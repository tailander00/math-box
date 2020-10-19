using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaConta : MonoBehaviour {

	public int preco;
    public Canvas canvas;
    public GameObject box;
	public GameObject aberta;
	private GameObject tela;

    void Start () {
    }
	
	void Update () {
		if (tela != null && tela.GetComponentInChildren<ControlaConta>().getCerto()) {
			tela.GetComponentInChildren<ControlaConta>().sair();
			abre ();
        }
	}

    public void OnCollisionEnter2D(Collision2D outro){
		if (outro.gameObject.CompareTag("jogador")) {
			Time.timeScale = 0;
			tela = Instantiate(box, canvas.transform.position, Quaternion.identity);
			tela.GetComponent<ControlaConta> ().setValor (preco);
        }
    }

	public void abre(){
		Instantiate(aberta,this.gameObject.transform.position , Quaternion.identity);
		Destroy (this.gameObject);

	}
}
