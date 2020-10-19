using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Arquivo : MonoBehaviour {

	private static String localArquivo;
	private static BinaryFormatter binario;
	private static Dados dados;
	private static String parada;
	private static bool existe;

	void Awake(){
		if(!existe){
			DontDestroyOnLoad(this.gameObject);
        	existe = true;  
		}    
	}

	void Start () {
		localArquivo = Application.persistentDataPath + "/save.dat";
		binario = new BinaryFormatter();

		if (File.Exists(localArquivo)) {
            FileStream arquivo = File.Open(localArquivo, FileMode.Open); //Aqui abrimos o arquivo

            dados = (Dados)binario.Deserialize(arquivo); //Aqui meio que descriptografamos o arquivo

            arquivo.Close(); //Aqui fechamos a leitura
        }else{
        	dados = new Dados();
        	dados.fase = "1";
        	dados.volumeMusica = 0.5f;
        	dados.volumeEfeitos = 1f;
        	salva();
        }

        if(0 != String.Compare(SceneManager.GetActiveScene().name , "gameOver")){
        	parada = SceneManager.GetActiveScene().name;
        }
	}

	public static void salva(){
        FileStream arquivo = File.Create(localArquivo);
		binario.Serialize(arquivo, dados);
        arquivo.Close();
	}

	public static String getFase(){
		return dados.fase;
	}

	public static float getVolumeMusica(){
		return dados.volumeMusica;
	}

	public static float getVolumeEfeitos(){
		return dados.volumeEfeitos;
	}

	public static String getParada(){
		return parada;
	}

	public static void setFase(String fase){
		dados.fase = fase;
	}

	public static void setVolumeMusica(float vol){
		dados.volumeMusica = vol;
	}

	public static void setVolumeEfeitos(float vol){
		dados.volumeEfeitos = vol;
	}
}