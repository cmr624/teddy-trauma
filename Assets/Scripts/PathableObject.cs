using UnityEngine;

public class PathableObject : MovableObject {

    public Vector2[] path;

    public override bool Frozen
    {
        get
        {
            return base.Frozen;
        }

        set
        {
            base.Frozen = value;

            StopPatrolLeg();
        }
    }

    private bool canPatrol;
    private int pathIndex;

    private Vector2 pathableFrameInput;

    protected override void Awake ()
    {
        base.Awake();
        if (path.Length > 0)
        {
            transform.position = path[0];
            if (path.Length > 1)
            {
                canPatrol = true;
                pathIndex = 1;

                StartPatrolLeg();
            }
        }
    }

    protected override void Update()
    {
        base.Update();

        if (canPatrol && Vector2.Distance(transform.position, path[pathIndex]) < 0.05f)
        {
            pathIndex = (pathIndex + 1) % path.Length;

            StartPatrolLeg();
        }
    }

    public void StartPatrolLeg()
    {
        StopPatrolLeg();

        if (path != null && canPatrol)
        {
            pathableFrameInput = MoveTowards(path[pathIndex]);
            Debug.Log("Start Patrol to :" + pathableFrameInput);
        }
    }

    public void StopPatrolLeg()
    {
        Debug.Log("Stopping patrol " + pathableFrameInput);
        MoveInDirection(-1 * pathableFrameInput);
        pathableFrameInput = Vector2.zero;
    }
}
