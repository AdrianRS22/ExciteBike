using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReturn : MonoBehaviour
{
    private SceneLoader sceneLoader;

    void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("DevolverPantallaPrincipal");
    }

    IEnumerator DevolverPantallaPrincipal()
    {
        yield return new WaitForSeconds(9);
        sceneLoader.PrimeraEscena();
    }
}
