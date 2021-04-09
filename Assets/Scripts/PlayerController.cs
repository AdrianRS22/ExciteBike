using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    private Animator animator;

    private Rigidbody2D rigidBody;

    private bool isRiding = false;

    private bool isMoving;

    private Vector3 origPos, targetPos;

    private float verticalTimeToMove = 0.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isRiding = true;
            rigidBody.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * speed, rigidBody.velocity.y);
            MovePlayerVertical();
        }
        MovePlayerVertical();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            isRiding = false;
            rigidBody.velocity = Vector2.zero;
        }
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        animator.SetBool("isRiding", isRiding);
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
