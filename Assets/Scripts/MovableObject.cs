using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MovableObject : MonoBehaviour {

    public enum Constraint
    {
        XPos,
        XNeg,
        YPos,
        YNeg
    }

    public bool affectedByPullers = true;
    public float speed;

    private Rigidbody2D rb;

    Dictionary<Wall, Constraint> touchingWalls;

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
        touchingWalls = new Dictionary<Wall, Constraint>();
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0f;
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
        
        foreach(Wall w in touchingWalls.Keys)
        {
            switch (touchingWalls[w])
            {
                case Constraint.XPos:
                    if (addMove.x > 0) { addMove.x = 0f; };
                    break;
                case Constraint.XNeg:
                    if (addMove.x < 0) { addMove.x = 0f; };
                    break;
                case Constraint.YPos:
                    if(addMove.y > 0) { addMove.y = 0f; };
                    break;
                case Constraint.YNeg:
                    if (addMove.y < 0) { addMove.y = 0f; };
                    break;
            }
        }

        rb.velocity = new Vector2(addMove.x + rb.velocity.x, addMove.y + rb.velocity.y);

        return addMove;
    }

    public Vector2 MoveInDirection(Vector2 dir, out bool wasConstrained, float? movementSpeed = null)
    {
        wasConstrained = touchingWalls.Count > 0;
        return MoveInDirection(dir, movementSpeed);
    }

    #region Hacky collision fix
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            SetContrains(collision, collision.gameObject.GetComponent<Wall>(), true);
        }
    }

    private bool Approx(float a, float b, float width)
    {
        return a > b - width && a < b + width;
    }

    
    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (wall != null && touchingWalls.ContainsKey(wall))
        {
            touchingWalls.Remove(wall);
        }
    }
    

    private void SetContrains(Collision2D collision, Wall wall, bool constrain)
    {
        Vector2 contactCenter = GetContactCenter(collision);

        if (Approx(transform.position.y, contactCenter.y, 0.05f) == false)
        {
            if (contactCenter.y - transform.position.y > 0)
            {
                Debug.Log("Constraining Y pos");

                touchingWalls[wall] = Constraint.YPos;
            }
            else
            {
                Debug.Log("Constraining Y neg");

                touchingWalls[wall] = Constraint.YNeg;
            }
        }

        if (Approx(transform.position.x, contactCenter.x, 0.05f) == false)
        {
            if (contactCenter.x - transform.position.x > 0)
            {
                Debug.Log("Constraining X pos");

                touchingWalls[wall] = Constraint.XPos;
            }
            else
            {
                Debug.Log("Constraining X neg");

                touchingWalls[wall] = Constraint.XNeg;
            }
        }
    }

    private Vector2 GetContactCenter(Collision2D collision)
    {

        ContactPoint2D[] contacts = new ContactPoint2D[collision.contacts.Length];
        collision.GetContacts(contacts);
        Vector2 contactCenter = Vector2.zero;
        foreach (ContactPoint2D c in contacts)
        {
            contactCenter.x += c.point.x;
            contactCenter.y += c.point.y;
        }
        return contactCenter / contacts.Length;
    }


    #endregion

    protected virtual void LateUpdate() { }

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }
}