using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 CurrentVelocity;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            //Debug.Log("up");
            if (Input.GetAxis("Horizontal") > 0)
            {
                //Debug.Log("up/right");
                rb.velocity = new Vector2(speed, speed);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                //Debug.Log("up/left");
                rb.velocity = new Vector2(-speed, speed);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                rb.velocity = new Vector2(0, speed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        else if (Input.GetKeyUp("up"))
        {
            rb.velocity = new Vector2(0, 0);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb.velocity = new Vector2(speed, -speed);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rb.velocity = new Vector2(-speed, -speed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                rb.velocity = new Vector2(0, -speed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        else if (Input.GetKeyUp("down"))
        {
            rb.velocity = new Vector2(0, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, 0);
        }
        //rb.velocity = new Vector2(CurrentVelocity.x, CurrentVelocity.y);

    }
}
