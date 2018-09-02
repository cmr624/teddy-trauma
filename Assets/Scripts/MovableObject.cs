using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MovableObject : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;

    private bool frozen;
    public virtual bool Frozen
    {
        get
        {
            return frozen;
        }
        set
        {
            frozen = value;

            rb.velocity = Vector2.zero;
        }
    }

    protected virtual void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    protected virtual void Update()
    {
        //blank
    }

    public Vector2 MoveTowards(Vector2 dest, float? movementSpeed = null)
    {
        if (Frozen) { return Vector2.zero; }

        return MoveInDirection(new Vector2(dest.x - transform.position.x, dest.y - transform.position.y), movementSpeed);
    }

    public Vector2 MoveInDirection(Vector2 dir, float? movementSpeed = null)
    {
        if (Frozen) { return Vector2.zero; }

        Vector2 addMove = dir.normalized * (movementSpeed.HasValue ? movementSpeed.Value : this.speed);
        rb.velocity = new Vector2(addMove.x + rb.velocity.x, addMove.y + rb.velocity.y);
        return addMove;
    }

    public virtual void OnEnable() { }

    public virtual void OnDisable() { }
}
