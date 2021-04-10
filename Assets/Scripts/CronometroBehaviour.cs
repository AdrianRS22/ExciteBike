using UnityEngine;
using UnityEngine.UI;
using System;

public class CronometroBehaviour : MonoBehaviour
{
    public float tiempo;
    public Text textoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        textoTiempo.text = "0:00:00";
        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalcularTiempo();
    }

    void CalcularTiempo()
    {
        tiempo += Time.deltaTime;

        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        int milisegundos = (int)(tiempo * 100) % 100;

        textoTiempo.text = string.Format("{0:0}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }
}
