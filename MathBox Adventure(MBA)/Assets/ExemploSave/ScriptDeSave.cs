using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScriptDeSave : MonoBehaviour {

    public int VariavelInteira; //Variavel que vai ser salva
    public float VariavelDecimal; //Variavel que vai ser salva
    public string VariavelTexto; //Variavel que vai ser salva
    public bool VariavelBooleana; //Variavel que vai ser salva

    [Header("Elementos da UI")]
    public Toggle Marcador;
    public InputField CampoTexto;
    public Text Inteira;
    public Text Decimal;
    public InputField Diretorio;

    [Header("Configurações")]
    public string DiretorioDoArquivo;
    public string FormatoDoArquivo;
    public string NomeDoArquivo;

    [Serializable] //Nessa parte nós meio que formatamos o nosso arquivo, criando uma classse para isso. Aqui criamos as variaveis que serão adicionadas ao arquivo, e vale notar que você pode repetir nome de variaveis, desde que uma delas esteja fora dessa classe.
    class DadosDoJogo
    {
        public int Int;
        public float Float;
        public string String;
        public bool Bool;
    }

    public void Save() //Void que salva
    {
        BinaryFormatter binario = new BinaryFormatter();
        FileStream arquivo = File.Create(DiretorioDoArquivo); //Aqui, criamos o arquivo

        DadosDoJogo dados = new DadosDoJogo(); //"DadosDoJogo" é o nome da classe que iremos acessar, ao qual criamos anteriormente
        dados.Int = VariavelInteira; //"dados.Int", é assim que acessamos uma variavel da nossa classe, para setar o valor dela, daí é só pegar e igualar com uma variavel do seu script.
        dados.Float = VariavelDecimal;
        dados.String = VariavelTexto;
        dados.Bool = VariavelBooleana;

        binario.Serialize(arquivo, dados);
        arquivo.Close(); //Aqui terminamos a leitura do arquivo.
    }

    public void Load() // Void que carrega
    {
        if (File.Exists(DiretorioDoArquivo) == true) //Aqui verificamos se existe um arquivo para ser carregado. se existir, prosseguimos
        {
            BinaryFormatter binario = new BinaryFormatter();
            FileStream arquivo = File.Open(DiretorioDoArquivo, FileMode.Open); //Aqui abrimos o arquivo
            DadosDoJogo dados = (DadosDoJogo)binario.Deserialize(arquivo); //Aqui meio que descriptografamos o arquivo

            VariavelInteira = dados.Int; //Aqui pegamos o valor salvo no arquivo e trazemos para nosso script.
            VariavelDecimal = dados.Float;
            VariavelTexto = dados.String;
            VariavelBooleana = dados.Bool;

            Marcador.isOn = VariavelBooleana;
            CampoTexto.text = VariavelTexto;

            arquivo.Close(); //Aqui fechamos a leitura
        }
    }

    void Update () {
        DiretorioDoArquivo = Application.persistentDataPath + "/" + NomeDoArquivo + "." + FormatoDoArquivo; //Aqui é definido o local de save, para o jogo.
        //Detalhe: "Application.persistentDataPath" é o local base onde o arquivo é salvo. Ele varia de plataforma para plataforma e de dispositivo para dispositivo. A unica coisa que não muda é o nome e formato do arquivo do seu save.

        //Daqui para baixo são só scripts da UI

        Inteira.text = VariavelInteira.ToString();
        Decimal.text = VariavelDecimal.ToString();

        VariavelBooleana = Marcador.isOn;
        VariavelTexto = CampoTexto.text;

        Diretorio.text = DiretorioDoArquivo;
    }

    public void AdicionarInt()
    {
        VariavelInteira += 1;
    }

    public void RemoverInt()
    {
        VariavelInteira -= 1;
    }

    public void AdicionarFloat()
    {
        VariavelDecimal += 0.5f;
    }

    public void RemoverFloat()
    {
        VariavelDecimal -= 0.5f;
    }
}
