using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;

    private Animator animator;

    private Rigidbody2D rigidBody;

    private bool isRiding = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isRiding = true;
            rigidBody.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * speed, rigidBody.velocity.y);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.2f)
        {
            var translation = new Vector3(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
            transform.Translate(translation);
        }
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
}
