using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;

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
                new Vector3(-Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            isRiding = false;
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.2f)
        {
            var translation =
                new Vector3(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
            transform.Translate(translation);
        }
    }

    private void LateUpdate()
    {
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        animator.SetBool("isRiding", isRiding);
    }
}
