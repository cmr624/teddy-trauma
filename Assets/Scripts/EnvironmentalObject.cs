using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentalObject : PathableObject {

    private List<MovableObject> movables;

    protected abstract void ActOnMovableObject(MovableObject obj);

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        MovableObject mo = collision.gameObject.GetComponent<MovableObject>();
        if (mo != null && mo.affectedByPullers)
        {
            movables.Add(mo);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        MovableObject mo = collision.gameObject.GetComponent<MovableObject>();
        if (mo != null && mo.affectedByPullers)
        {
            movables.Remove(mo);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        movables = new List<MovableObject>();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        foreach(MovableObject mo in movables)
        {
            ActOnMovableObject(mo);
        }
    }
}
