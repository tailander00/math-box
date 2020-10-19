using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour {

	public GameObject inicio2;

	void start(){
		inicio2.SetActive(false);
	}

    public void comacar() {
        inicio2.SetActive(true);
    }

}
