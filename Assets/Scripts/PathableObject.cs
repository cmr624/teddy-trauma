﻿using UnityEngine;

public class PathableObject : MovableObject {

    public Vector2[] path;


    public Vector2? TargetPosition
    {
        get
        {
            if(path != null && pathIndex < path.Length)
            {
                return path[pathIndex];
            } else
            {
                return null;
            }
        }
    }

    private bool canPatrol;
    private int pathIndex;

    private Vector2 pathableFrameInput;

    private EnemyRotate rotate;

    protected override void Awake ()
    {
        base.Awake();

        rotate = GetComponentInChildren<EnemyRotate>();

        if (path.Length > 0)
        {
            transform.position = path[0];
            if (path.Length > 1)
            {
                canPatrol = true;
                pathIndex = 1;

                Patrol();
            }
        }
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        if (canPatrol )
        {
            Patrol();

            if (Vector2.Distance(transform.position, path[pathIndex]) < 0.05f)
            {
                pathIndex = (pathIndex + 1) % path.Length;
            }
        }
    }

    public void Patrol()
    {
        if(Frozen == false)
        {
            Stop();

            if (rotate != null)
            {
                rotate.RotateTowards(path[pathIndex]);
            }

            if (path != null && canPatrol)
            {
                pathableFrameInput = MoveTowards(path[pathIndex]);
            }
        }
    }

    public void Stop()
    {
        Debug.Log("Stopping patrol " + pathableFrameInput);
        MoveInDirection(-1 * pathableFrameInput);
        pathableFrameInput = Vector2.zero;
    }
}
