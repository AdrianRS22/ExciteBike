using System;
using UnityEngine;

[Serializable]
public class Sound
{
    [SerializeField]
    public string nombre;

    [SerializeField]
    public AudioClip sonido;

    [HideInInspector]
    public AudioSource source;

    [SerializeField]
    [Range(0F, 1F)]
    public float volumen;

    [SerializeField]
    public bool repetir;
}
