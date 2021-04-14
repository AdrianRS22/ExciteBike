using UnityEngine;
using Pathfinding;

public class EnemyController : Character2DController
{
    public AIPath aiPath;

    protected override void Awake()
    {
        base.Awake();
        aiPath.canMove = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.inicioJuego)
        {
            aiPath.canMove = true;
        }

        aiPath.maxSpeed = baseSpeed * cambioVelocidad;
        animator.SetFloat(GameConstants.AXIS_H, Mathf.Round(aiPath.desiredVelocity.normalized.x));
        animator.SetFloat(GameConstants.AXIS_V, Mathf.Round(aiPath.desiredVelocity.normalized.y));
    }
}
