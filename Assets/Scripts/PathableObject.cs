using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathableObject : MovableObject {

    public Vector2[] path;
    private bool willMove;
    private int pathIndex;

	protected override void Start ()
    {
        base.Start();
        if (path.Length > 0)
        {
            transform.position = path[0];
            if (path.Length > 1)
            {
                willMove = true;
                pathIndex = 1;

                MoveTowards(path[1]);
            }
        }
    }

    protected override void Update()
    {
        base.Update();

        if (willMove && Vector2.Distance(transform.position, path[pathIndex]) < 0.01f)
        {
            MoveTowards(path[pathIndex]);
            pathIndex = (pathIndex + 1) % path.Length;
        }
    }
}
