using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentalObject : PathableObject {

    private List<MovableObject> movables;

    protected abstract void ActOnMovableObject(MovableObject obj);

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrance");

        if (collision.gameObject.GetComponent<MovableObject>() != null)
        {
            movables.Add(collision.gameObject.GetComponent<MovableObject>());
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.GetComponent<MovableObject>() != null)
        {
            movables.Remove(collision.gameObject.GetComponent<MovableObject>());
        }
    }

    protected override void Start()
    {
        base.Start();

        movables = new List<MovableObject>();
    }

    protected override void Update()
    {
        base.Update();

        foreach(MovableObject mo in movables)
        {
            ActOnMovableObject(mo);
        }
    }
}
