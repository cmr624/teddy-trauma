using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : EnvironmentalObject
{
    public float pullSpeed;
    public Vector2 endPoint;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        MovableObject mo = collision.gameObject.GetComponent<MovableObject>();

        if(mo != null)
        {
            Debug.Log("last frame input: " + lastFrameInput);
            mo.MoveInDirection(-1 * lastFrameInput, pullSpeed);
        }

        lastFrameInput = Vector2.zero;
    }

    private Vector2 lastFrameInput;
    protected override void ActOnMovableObject(MovableObject obj)
    {
        obj.MoveInDirection(-1 * lastFrameInput, pullSpeed);

        lastFrameInput = obj.MoveTowards(endPoint, pullSpeed);
    }
}
