using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
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
    }

    // Start is called before the first frame update
    void Start()
    {
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
}
