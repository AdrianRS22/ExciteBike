using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ProximaEscena()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
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
