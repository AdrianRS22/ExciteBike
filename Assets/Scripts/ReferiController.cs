using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferiController : MonoBehaviour
{
    [SerializeField]
    public Transform movePosition;
    /// <summary>
    /// Valor del parametro para mover al referi en el animador
    /// </summary>
    private bool isMoving;

    private GameController gameController;

    private Animator animator;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        isMoving = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            return;
        }

        if(gameObject.name.Equals("CuartoReferi") && gameController.raceFinished)
        {
            AnimateReferi();
        }

        if (!gameObject.name.Equals("CuartoReferi"))
        {

            if(movePosition.position.x > gameObject.transform.position.x)
            {
                AnimateReferi();
            }
        }
    }

    void AnimateReferi()
    {
        isMoving = true;
        animator.SetBool("isMoving", true);
        
    }
}
