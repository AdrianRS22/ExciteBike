using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SceneReturn : MonoBehaviour
{
    public Text scoreText;
    private SceneLoader sceneLoader;

    void Start()
    {
        var scoreList = SaveLoadManager.LoadData<List<Score>>("Data", "score");
        var recentScore = scoreList.OrderByDescending(o => o.dateCreated).First();
        scoreText.text = recentScore.text;
    }

    void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("DevolverPantallaPrincipal");
    }

    IEnumerator DevolverPantallaPrincipal()
    {
        yield return new WaitForSeconds(9);
        sceneLoader.PrimeraEscena();
    }
}
