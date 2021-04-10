using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Start()
    {
        Play("Theme");
    }

    void Awake()
    {
        foreach(var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.sonido;
            sound.source.volume = sound.volumen;
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
