using UnityEngine;

public class PlayerController : Character2DController
{
    /// <summary>
    /// Velocidad del jugador en modo base
    /// </summary>
    private readonly float baseSpeed = 10f;

    /// <summary>
    /// Velocidad del jugador utilizando el temporizador
    /// </summary>
    private readonly float tempSpeed = 20f;

    /// <summary>
    /// Velocidad actual del jugador
    /// </summary>
    private float currentSpeed;

    /// <summary>
    ///  Propiedad que permite detener al player de moverse
    /// </summary>
    public bool hasStop = false;

    private TempController tempController;

    /// <summary>
    ///  Le indicará al player en que punto debe de moverse
    /// </summary>
    [SerializeField]
    public Transform movePoint;

    /// <summary>
    ///  Esto indicara en donde el movePoint no se puede asignar para mover al personaje
    /// </summary>
    [SerializeField]
    public LayerMask whatStopsMovement;

    protected override void Awake()
    {
        base.Awake();
        tempController = FindObjectOfType<TempController>();
    }

    void Start()
    {
        movePoint.parent = null;
    }


    void Update()
    {
        if (gameController.inicioJuego)
        {
            if (hasStop)
            {
                return;
            }

            if (Input.GetKey(GameConstants.RideKeyCode) || Input.GetKey(GameConstants.RideTempKeyCode))
            {
                if (Input.GetKey(GameConstants.RideKeyCode))
                {
                    currentSpeed = baseSpeed;
                }
                else if (Input.GetKey(GameConstants.RideTempKeyCode))
                {
                    currentSpeed = tempSpeed;
                    StartCoroutine(tempController.RevisarTemporizador());
                }
            }
            MovePlayer();
        }
    }

    private void LateUpdate()
    {
        if (hasStop)
        {
            return;
        }
        animator.SetFloat(GameConstants.AXIS_H, Input.GetAxisRaw(GameConstants.AXIS_H));
        animator.SetFloat(GameConstants.AXIS_V, Input.GetAxisRaw(GameConstants.AXIS_V));
    }

    private void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, (currentSpeed * cambioVelocidad) * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw(GameConstants.AXIS_H)) > .2f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw(GameConstants.AXIS_H), 0f, 0f), .5f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw(GameConstants.AXIS_H), 0f, 0f);
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw(GameConstants.AXIS_V)) > .2f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw(GameConstants.AXIS_V), 0f), .5f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw(GameConstants.AXIS_V), 0f);
                }
            }
        }
    }

    public bool IsPlayerInTempMode()
    {
        return currentSpeed > baseSpeed;
    }

    public void DetenerJugador()
    {
        animator.SetFloat(GameConstants.AXIS_H, 0);
        animator.SetFloat(GameConstants.AXIS_V, 0);
        hasStop = true;
    }

    public void JugadorHaFinalizadoCarrera()
    {
        animator.SetBool("Winning", true);
    }
}
