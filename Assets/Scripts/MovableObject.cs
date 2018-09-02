using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MovableObject : MonoBehaviour {

    public bool affectedByPullers = true;
    public float speed;

    private Rigidbody2D rb;

    private bool constrainXPos, constrainXNeg, constrainYPos, constrainYNeg;

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
        
        if((addMove.x > 0 && constrainXPos) || (addMove.x < 0 && constrainXNeg))
        {
            Debug.Log("Constrained X");
            addMove.x = 0;
        }

        if ((addMove.y > 0 && constrainYPos) || (addMove.y < 0 && constrainYNeg))
        {
            Debug.Log("Constrained Y");
            addMove.y = 0;
        }

        Debug.Log("Adding move: " + addMove);

        rb.velocity = new Vector2(addMove.x + rb.velocity.x, addMove.y + rb.velocity.y);
        return addMove;
    }

    #region Hacky collision fix
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        SetContrains(collision, true);
    }

    private bool Approx(float a, float b, float width)
    {
        return a > b - width && a < b + width;
    }

    
    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        SetContrains(collision, false);
    }
    

    private void SetContrains(Collision2D collision, bool constrain)
    {

        if (Approx(transform.position.y, collision.transform.position.y, 0.05f) == false)
        {
            if (collision.transform.position.y - transform.position.y > 0)
            {
                Debug.Log("Constraining Y pos");

                constrainYPos = constrain;
            }
            else
            {
                Debug.Log("Constraining Y neg");

                constrainYNeg = constrain;
            }
        }

        if (Approx(transform.position.x, collision.transform.position.x, 0.05f) == false)
        {
            if (collision.transform.position.x - transform.position.x > 0)
            {
                Debug.Log("Constraining X pos");

                constrainXPos = constrain;
            }
            else
            {
                Debug.Log("Constraining X neg");

                constrainXNeg = constrain;
            }
        }
    }

        /*
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
    */
    #endregion

    protected virtual void LateUpdate() { }

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }
}