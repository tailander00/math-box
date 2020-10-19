using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    private Vector2 target;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        target = new Vector2(transform.position.x, transform.position.y);
        target.x = Mathf.Lerp(transform.position.x, Jogador.jogador.gameObject.transform.position.x, 8.0f * Time.deltaTime);
        target.y = Mathf.Lerp(transform.position.y, Jogador.jogador.gameObject.transform.position.y, 8.0f * Time.deltaTime);

        transform.position = new Vector3(target.x, target.y, transform.position.z);

        if(Time.timeScale == 0){
            gameObject.GetComponent<AudioSource>().volume = 0;
        }else{
            gameObject.GetComponent<AudioSource>().volume = Arquivo.getVolumeMusica();
        }
	}
}
