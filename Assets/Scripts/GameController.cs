using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool inicioJuego = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(11);
        inicioJuego = true;
    }
}
