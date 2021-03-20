using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    public Rigidbody2D body;

    Vector3 currentPosition;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentPosition.y = -1.9F;
        }
    }

    void FixedUpdate()
    {
        body.position = Vector3.MoveTowards(body.position, currentPosition, speed * Time.deltaTime);
    }
}
