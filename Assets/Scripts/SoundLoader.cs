using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private AudioManager audioManager;

    /// <summary>
    ///  Esta variable indica si la cuenta regresiva en el primer nivel ha pasado o no
    /// </summary>
    private bool haPasadoCuentaRegresiva;

    void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioManager.Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        CargarSonidos(sceneLoader.escenaActual);
    }

    private void CargarSonidos(int escenaActual)
    {
        if(escenaActual == 1 && !haPasadoCuentaRegresiva)
        {
            var themeScene = audioManager.Fetch("Theme");

            if (!themeScene.source.isPlaying)
            {
                audioManager.Play("cuentaRegresiva");
                haPasadoCuentaRegresiva = true;
            }
        }

    }
}
