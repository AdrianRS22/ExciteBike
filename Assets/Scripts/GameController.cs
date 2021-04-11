using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool inicioJuego = false;


    /// <summary>
    ///  Controlador del game object que posee todos los starting marks
    /// </summary>
    private StartingMarksController startingMarks;

    void Awake()
    {
        startingMarks = FindObjectOfType<StartingMarksController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        if (!inicioJuego)
        {
            yield return new WaitForSecondsRealtime(13);
            startingMarks.ClosingStartingMarks();
            yield return new WaitForSecondsRealtime(1);
            inicioJuego = true;
        }

    }
}
