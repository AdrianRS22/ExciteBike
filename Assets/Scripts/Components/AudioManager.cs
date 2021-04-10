using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    ///  propiedad temporal para mutear el audioManager
    /// </summary>
    [SerializeField]
    public bool isMute = true;

    public Sound[] sounds;

    void Start()
    {
        if (!isMute)
        {
            Play("Theme");
        }
    }

    void Awake()
    {
        foreach(var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.sonido;
            sound.source.volume = sound.volumen;
            sound.source.loop = sound.repetir;
        }
    }

    public void Play(string nombre)
    {
        var sound = Array.Find(sounds, x => x.nombre.Equals(nombre));

        if(sound == null)
        {
            Debug.LogFormat("El audio {0} no fue encontrado.", nombre);
            return;
        }

        sound.source.Play();
    }

    public void Stop(string nombre)
    {
        var sound = Array.Find(sounds, x => x.nombre.Equals(nombre));

        if (sound == null)
        {
            Debug.LogFormat("El audio {0} no fue encontrado.", nombre);
            return;
        }

        sound.source.Stop();

    }
}
