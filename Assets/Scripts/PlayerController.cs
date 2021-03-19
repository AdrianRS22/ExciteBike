using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    public Transform target2;

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

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentPosition = target.position;
            currentPosition.z = 1F;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentPosition, speed * Time.deltaTime);
    }
}
