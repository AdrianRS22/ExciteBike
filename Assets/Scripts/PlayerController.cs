using System.Collections;
using System.Collections.Generic;
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
    /// Propiedad que se asignara en el animador para comparar si el personaje se esta moviendo o no
    /// </summary>
    private bool isRiding = false;

    /// <summary>
    ///  Propiedad que permite detener al player de moverse
    /// </summary>
    public bool hasStop = false;

    private bool isVerticalMoving = false;

    private Vector3 origPos, targetPos;

    private readonly float verticalTimeToMove = 0.2f;

    private TempController tempController;

    protected override void Awake()
    {
        base.Awake();
        tempController = FindObjectOfType<TempController>();
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

                isRiding = true;

                if (Input.GetKey(GameConstants.RideKeyCode))
                {
                    currentSpeed = baseSpeed;
                }
                else if (Input.GetKey(GameConstants.RideTempKeyCode))
                {
                    currentSpeed = tempSpeed;
                    StartCoroutine(tempController.RevisarTemporizador());
                }

                Vector3 translation = new Vector3(-Input.GetAxisRaw(GameConstants.AXIS_H) * currentSpeed * Time.deltaTime, 0, 0);
                transform.Translate(translation);

                MovePlayerVertical();
            }

            MovePlayerVertical();
        }
    }

    private void LateUpdate()
    {
        if (gameController.inicioJuego)
        {
            if (!hasStop)
            {
                if(Input.GetKeyUp(GameConstants.RideKeyCode) || Input.GetKeyUp(GameConstants.RideTempKeyCode))
                {
                    isRiding = false;
                }
                animator.SetBool("isRiding", isRiding);
                animator.SetFloat(GameConstants.AXIS_V, Input.GetAxisRaw(GameConstants.AXIS_V));
            }
        }
    }

    private void MovePlayerVertical()
    {
        if (isVerticalMoving)
        {
            return;
        };

        if (Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isVerticalMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < verticalTimeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / verticalTimeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isVerticalMoving = false;
    }

    public bool IsPlayerInTempMode()
    {
        return currentSpeed > baseSpeed;
    }

    public void DetenerJugador()
    {
        isRiding = false;
        animator.SetBool("isRiding", isRiding);
        hasStop = true;
    }
}
