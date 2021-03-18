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
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
        DateTime resultado = DateTime.MinValue.Add(timeSpan);
        textoTiempo.text = string.Format("{0:0}:{1:00}:{2:00}", resultado.Minute, resultado.Second, (resultado.Millisecond / 10));
    }
}
