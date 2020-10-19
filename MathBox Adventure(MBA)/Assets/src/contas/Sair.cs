using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair : MonoBehaviour {
    public GameObject box;

    public void onclick() {
        DestroyObject(box);
    }
}
