using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int escenaActual;

    void Awake()
    {
        escenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    public void ProximaEscena()
    {
        SceneManager.LoadScene(escenaActual + 1);
    }

    public void PrimeraEscena()
    {
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
