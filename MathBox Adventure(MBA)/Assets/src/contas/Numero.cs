using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Numero : MonoBehaviour {
	public InputField[] entrada;
    private int i;

	public void OnClick(String num){
		if (num == "<=") {
            entrada[i].text = entrada[i].text.Remove (entrada[i].text.Length - 1);
		} else {
            entrada[i].text += num;
		}
		
	}

    public void Awake(){
        i = 0;
    }

    public void increment() {
        ++i;
    }

    public void decrement() {
        --i;   
    }

    public void Update(){
        if (i >= 4){
            i = 0;
        }else if (i < 0) {
            i = 3;
        }

        entrada[i].ActivateInputField();
    }
}
