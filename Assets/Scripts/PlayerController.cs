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
    /// Modelo de Ride Movement para darle play al efecto de sonido del ride
    /// </summary>
    private RideMovementSound rideMovementSound;

    private bool isRiding = false;

    private bool hasStop = false;

    private bool isVerticalMoving = false;

    private Vector3 origPos, targetPos;

    private readonly float verticalTimeToMove = 0.2f;

    private AudioManager audioManager;

    private TempController tempController;

    protected override void Awake()
    {
        base.Awake();
        audioManager = FindObjectOfType<AudioManager>();
        rideMovementSound = null;
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
                    rideMovementSound = new RideMovementSound
                    {
                        KeyCode = GameConstants.RideKeyCode,
                        SoundEffect = "Ride"
                    };
                }
                else if (Input.GetKey(GameConstants.RideTempKeyCode))
                {
                    currentSpeed = tempSpeed;
                    rideMovementSound = new RideMovementSound
                    {
                        KeyCode = GameConstants.RideTempKeyCode,
                        SoundEffect = "RideTemp"
                    };
                    StartCoroutine(TempLogic());
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
                if (rideMovementSound != null)
                {
                    PlayRideSound(rideMovementSound.KeyCode, rideMovementSound.SoundEffect);
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

    private void PlayRideSound(KeyCode code, string effectName)
    {
        if (Input.GetKeyDown(code))
        {
            audioManager.PlayOneShot(effectName);
        }

        if (Input.GetKeyUp(code))
        {
            isRiding = false;

            audioManager.Stop(effectName);
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

    IEnumerator TempLogic()
    {
        var overHeated = tempController.overheated;

        if (!overHeated)
        {
            var currTempBarValue = tempController.tempBar.value;
            var maxTempValue = tempController.tempBar.maxValue;

            if (currTempBarValue == maxTempValue)
            {
                tempController.overheated = true;
                audioManager.Stop("RideTemp");
                isRiding = false;
                hasStop = true;
                yield return new WaitForSeconds(5);
                tempController.overheated = false;
                tempController.overheatedContinue = true;
                tempController.tempBar.value = 25f;
                yield return new WaitForSeconds(3);
                tempController.overheatedContinue = false;
                hasStop = false;
            }
            else if(currTempBarValue < maxTempValue)
            {
                tempController.IncreaseTemp(0.1f);
            }
        }
    }
}
