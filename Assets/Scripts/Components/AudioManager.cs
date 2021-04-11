using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (var sound in sounds)
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

    public Sound Fetch(string nombre)
    {
        return Array.Find(sounds, x => x.nombre.Equals(nombre));
    }
}
