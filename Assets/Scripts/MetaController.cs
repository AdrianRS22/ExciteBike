using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MetaController : MonoBehaviour
{
    private SFXTracker sfxTracker;

    private AudioManager audioManager;

    private SceneLoader sceneLoader;

    private CronometroBehaviour cronometroBehaviour;

    private List<Score> scoreList;

    void Awake()
    {
        sfxTracker = FindObjectOfType<SFXTracker>();
        audioManager = FindObjectOfType<AudioManager>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        cronometroBehaviour = FindObjectOfType<CronometroBehaviour>();
    }

    void Start()
    {
        scoreList = SaveLoadManager.LoadData<List<Score>>("Data", "score") ?? new List<Score>();
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
        SaveScore();
        sceneLoader.ProximaEscena();
    }

    private void SaveScore()
    {
        var score = new Score
        {
            text = cronometroBehaviour.textoTiempo.text,
            value = cronometroBehaviour.tiempo,
            dateCreated = DateTime.Now
        };
        scoreList.Add(score);
        SaveLoadManager.SaveData(scoreList, "Data", "score");
    }
}
