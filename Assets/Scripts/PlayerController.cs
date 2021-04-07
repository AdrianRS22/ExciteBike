using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";

    private Animator animator;

    private bool isRiding = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isRiding = true;
            var translation =
                new Vector3(-Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            isRiding = false;
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            var translation =
                new Vector3(0, Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            transform.Translate(translation);
        }
    }

    private void LateUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxisRaw(AXIS_H));
        animator.SetFloat("Vertical", Input.GetAxisRaw(AXIS_V));
        animator.SetBool("isRiding", isRiding);
    }
}
