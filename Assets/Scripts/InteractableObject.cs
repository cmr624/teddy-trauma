using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : EnvironmentalObject {

    public KeyCode interactKey = KeyCode.Space;

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
    }

    protected override void ActOnMovableObject(MovableObject obj)
    {
        if (Input.GetKeyDown(interactKey))
        {
            Interact();
        }
    }

    protected abstract void Interact();
}
