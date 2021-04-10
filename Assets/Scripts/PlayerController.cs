using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character2DController
{
    [SerializeField]
    public float speed = 5f;

    private bool isRiding = false;

    private bool isMoving = false;

    private Vector3 origPos, targetPos;

    private readonly float verticalTimeToMove = 0.2f;

    private AudioManager audioManager;

    protected override void Awake()
    {
        base.Awake();
        audioManager = FindObjectOfType<AudioManager>();
    }



    void Update()
    {
        if (gameController.inicioJuego)
        {
            if (Input.GetKey(KeyCode.A))
            {
                isRiding = true;

                Vector3 translation = new Vector3(-Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
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
            PlayRideSound(KeyCode.A, "Ride");
            animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            animator.SetBool("isRiding", isRiding);
        }
    }

    private void MovePlayerVertical()
    {
        if (isMoving)
        {
            return;
        }

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
            audioManager.Play(effectName);
        }

        if (Input.GetKeyUp(code))
        {
            isRiding = false;
            audioManager.Stop(effectName);
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

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

        isMoving = false;
    }
}
