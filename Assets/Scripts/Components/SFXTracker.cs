using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTracker : MonoBehaviour
{
    public AudioSource[] soundFX;

    private GameController gameController;

    /// <summary>
    ///  Esta propiedad permite detectar cuando se ha presionado cualquier tecla
    /// </summary>
    private bool holdingDown;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    void Update()
    {
        if (gameController.inicioJuego)
        {
            if (Input.anyKeyDown)
            {
                PlaySFX(GameConstants.RideKeyCode, GameConstants.SFXType.RIDE);
                PlaySFX(GameConstants.RideTempKeyCode, GameConstants.SFXType.RIDE_TEMP);
                holdingDown = true;
            }

            if(!Input.anyKey && holdingDown)
            {
                StopAll();
            }
        }
    }

    /// <summary>
    /// Detiene todos los audios
    /// </summary>
    public void StopAll()
    {
        foreach(var sound in soundFX)
        {
            sound.Stop();
        }
    }

    /// <summary>
    /// Este metodo es para iniciar el audio enlazandole con el input manager
    /// </summary>
    /// <param name="inputKey"></param>
    /// <param name="type"></param>
    void PlaySFX(KeyCode inputKey, GameConstants.SFXType type)
    {
        if (Input.GetKeyDown(inputKey))
        {
            StopAll();
            var audioFound = Fetch(type);

            if(audioFound != null)
            {
                audioFound.Play();
            }
        }
    }

    /// <summary>
    /// Este metodo es para iniciar un audio pasando como parametro la posicion del audio en el arreglo
    /// </summary>
    /// <param name="indexPosition"></param>
    void PlaySFX(int indexPosition)
    {
        StopAll();
        soundFX[indexPosition].Play();
    }

    public void StopSFX(GameConstants.SFXType type)
    {
        var audioFound = Fetch(type);

        if(audioFound != null)
        {
            audioFound.Stop();
        }
    }

    /// <summary>
    /// Devuelve el audio basado en el tipo de efecto de sonido
    /// </summary>
    /// <param name="type"></param>
    /// <returns>AudioSource</returns>
    AudioSource Fetch(GameConstants.SFXType type)
    {
        AudioSource audio = null;
        switch (type)
        {
            case GameConstants.SFXType.RIDE:
                audio = soundFX[0];
                break;
            case GameConstants.SFXType.RIDE_TEMP:
                audio = soundFX[1];
                break;
            case GameConstants.SFXType.TEMP_ALMOST_FULL:
                audio = soundFX[2];
                break;
        }
        return audio;
    }
}
