using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : EnvironmentalObject
{
    [Header("Puller Options")]
    public bool constrainX;
    public bool constrainY;
    public float pullSpeed;
    public Vector2 endPoint;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
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
            mo.MoveInDirection(-1 * pullerFrameInput, pullSpeed);
        }

        pullerFrameInput = Vector2.zero;
    }

    private Vector2 pullerFrameInput;
    protected override void ActOnMovableObject(MovableObject obj)
    {
        obj.MoveInDirection(-1 * pullerFrameInput, pullSpeed);

        Vector2 realisedEndPoint = endPoint;

        if (constrainX)
        {
            realisedEndPoint.x = obj.transform.position.x;
        }

        if (constrainY)
        {
            realisedEndPoint.y = obj.transform.position.y;
        }

        pullerFrameInput = obj.MoveTowards(realisedEndPoint, pullSpeed);
    }
    public void reverse1(){
        endPoint=new Vector2(5.767434f,1.49f);
    }
    public void reverse2()
    {
        endPoint =new Vector2(6.2f,1.2f);
    }

}
