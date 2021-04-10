using UnityEngine;

public class Character2DController : MonoBehaviour
{
    protected Animator animator;

    protected GameController gameController;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"El valor del inicio del juego es {gameController.inicioJuego}");
    }


}
