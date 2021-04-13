using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CronometroBehaviour : MonoBehaviour
{
    public float tiempo;
    public Text textoTiempo;
    public Text textoBestScore;

    private GameController gameController;

    void Awake()
    {
        textoBestScore.text = string.Empty;
        gameController = FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        textoTiempo.text = "0:00:00";
        tiempo = 0;
        ObtenerMejorPuntuacion();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.inicioJuego && !gameController.raceFinished)
        {
            CalcularTiempo();
        }
    }

    void CalcularTiempo()
    {
        tiempo += Time.deltaTime;

        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        int milisegundos = (int)(tiempo * 100) % 100;

        textoTiempo.text = string.Format("{0:0}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }

    void ObtenerMejorPuntuacion()
    {
        var scoreList = SaveLoadManager.LoadData<List<Score>>("Data", "score");
        if(scoreList.Count > 0)
        {
            textoBestScore.text = scoreList.OrderBy(o => o.value).First().text;
        }
    }
}
