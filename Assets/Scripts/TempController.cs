using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TempController : MonoBehaviour
{
    /// <summary>
    /// Barra temporizador que esta en el canvas
    /// </summary>
    private Slider tempBar;

    /// <summary>
    ///  Propiedad que indica si la moto se sobrecalento
    /// </summary>
    [SerializeField]
    public bool overheated = false;

    /// <summary>
    /// Propiedad que indica cuando la moto se ha restablecido del sobrecalentamiento
    /// </summary>
    [SerializeField]
    public bool overheatedContinue = false;


    /// <summary>
    /// Propiedad para darle un efecto de parpadeo al overheated
    /// </summary>
    private bool overheatedBlinkingText = false;

    /// <summary>
    ///  Los estilos que tendran over heated y go
    /// </summary>
    private GUIStyle estilosLetraTemporizador;

    /// <summary>
    /// Controlador del personaje
    /// </summary>
    private PlayerController playerController;

    /// <summary>
    /// Controlador que se encarga de darle seguimiento a todos los efectos de sonido cargados en la escena
    /// </summary>
    private SFXTracker sfxTracker;

    private void Awake()
    {
        estilosLetraTemporizador = new GUIStyle
        {
            fontSize = 25,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState
            {
                textColor = Color.white
            }
        };
        tempBar = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController>();
        sfxTracker = FindObjectOfType<SFXTracker>();
    }

    // Start is called before the first frame update
    void Start()
    {
        tempBar.maxValue = 100;
        tempBar.value = 25;
        StartCoroutine(BlinkingOverHeadedText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (overheated)
        {
            if (overheatedBlinkingText)
            {
                GUI.Label(new Rect(240, 140, 200, 2000), "OVER HEAT", estilosLetraTemporizador);
            }
        }

        if (overheatedContinue)
        {
            GUI.Label(new Rect(300, 140, 200, 2000), "GO", estilosLetraTemporizador);
        }
    }

    IEnumerator BlinkingOverHeadedText()
    {
        while (true)
        {
            overheatedBlinkingText = true;
            yield return new WaitForSeconds(.5f);
            overheatedBlinkingText = false;
            yield return new WaitForSeconds(.5f);
        }
    }

    public void IncreaseTemp(float increaseValue)
    {
        if(tempBar.value < tempBar.maxValue)
        {
            tempBar.value += increaseValue;
        }
    }

    public IEnumerator RevisarTemporizador()
    {
        bool isTempMode = playerController.IsPlayerInTempMode();
        if (isTempMode)
        {
            if (tempBar.value == tempBar.maxValue)
            {
                overheated = true;
                sfxTracker.StopAll();
                playerController.DetenerJugador();
                yield return new WaitForSeconds(5);

                RecargandoTemporizador();
                yield return new WaitForSeconds(1);

                playerController.hasStop = false;
                overheatedContinue = false;

                yield return null;
            }
            else
            {
                IncreaseTemp(0.1f);
                yield return null;
            }
        }
    }

    public void RecargandoTemporizador()
    {
        tempBar.value = 25f;
        overheated = false;
        overheatedContinue = true;
    }
}
