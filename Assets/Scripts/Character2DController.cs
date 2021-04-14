using UnityEngine;

public class Character2DController : MonoBehaviour
{
    protected Animator animator;

    protected GameController gameController;

    /// <summary>
    /// Velocidad del jugador en modo base
    /// </summary>
    protected readonly float baseSpeed = 10f;

    /// <summary>
    ///  Esta propiedad va a permitir definir ritmos de velocidad y se usara con el fin de que si el objecto colisiona con un obstaculo
    ///  el objeto sera mas lento
    /// </summary>
    protected float cambioVelocidad = 1f;

    protected virtual void Awake()
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

    }

    public float CambioDeVelocidad {
        get { return cambioVelocidad; }
        set { cambioVelocidad = value; }
    }
}
