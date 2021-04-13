using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTracker : MonoBehaviour
{
    public AudioSource[] soundFX;

    private GameController gameController;

    private PlayerController playerController;

    /// <summary>
    ///  Esta propiedad permite detectar cuando se ha presionado cualquier tecla
    /// </summary>
    private bool holdingDown;

    /// <summary>
    /// Tipos de efectos de sonido que va a tener el juego
    /// </summary>
    private enum SFXType
    {
        RIDE,
        RIDE_TEMP,
        WINNING,
        TEMP_ALMOST_FULL
    }

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (gameController.inicioJuego)
        {
            if (playerController.hasStop || gameController.raceFinished)
            {
                return;
            }

            if (Input.anyKeyDown)
            {
                PlaySFX(GameConstants.RideKeyCode, SFXType.RIDE);
                PlaySFX(GameConstants.RideTempKeyCode, SFXType.RIDE_TEMP);
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
    void PlaySFX(KeyCode inputKey, SFXType type)
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

    void StopSFX(SFXType type)
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
    AudioSource Fetch(SFXType type)
    {
        AudioSource audio = null;
        switch (type)
        {
            case SFXType.RIDE:
                audio = soundFX[0];
                break;
            case SFXType.RIDE_TEMP:
                audio = soundFX[1];
                break;
            case SFXType.TEMP_ALMOST_FULL:
                audio = soundFX[2];
                break;
        }
        return audio;
    }
}
