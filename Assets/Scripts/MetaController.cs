using System.Collections;
using UnityEngine;

public class MetaController : MonoBehaviour
{
    private SFXTracker sfxTracker;

    private AudioManager audioManager;

    private SceneLoader sceneLoader;

    private CronometroBehaviour cronometroBehaviour;

    void Awake()
    {
        sfxTracker = FindObjectOfType<SFXTracker>();
        audioManager = FindObjectOfType<AudioManager>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        cronometroBehaviour = FindObjectOfType<CronometroBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sfxTracker.StopAll();
            audioManager.Play("finishRace");

            var playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.JugadorHaFinalizadoCarrera();
            StartCoroutine("MoverEscenaGameOver");
        }
    }

    IEnumerator MoverEscenaGameOver()
    {
        yield return new WaitForSeconds(6);
        //Debug.Log(cronometroBehaviour.tiempo);
        //Debug.Log(cronometroBehaviour.textoTiempo.text);
        sceneLoader.ProximaEscena();
    }
}
