using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : Character2DController
{
    public AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        aiPath.maxSpeed = baseSpeed * cambioVelocidad;
        animator.SetFloat(GameConstants.AXIS_H, Mathf.Round(aiPath.desiredVelocity.normalized.x));
        animator.SetFloat(GameConstants.AXIS_V, Mathf.Round(aiPath.desiredVelocity.normalized.y));
    }
}
