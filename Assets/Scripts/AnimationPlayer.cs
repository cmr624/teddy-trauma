using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{

	private Animator animator;
	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis("Horizontal") < 0)
		{
			animator.SetTrigger("left");
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			animator.SetTrigger("right");
		}
		else if (Input.GetAxis("Vertical") < 0)
		{
			animator.SetTrigger("down");
		}
		else if (Input.GetAxis("Vertical") > 0)
		{
			animator.SetTrigger("up");
		}
		if (!Input.anyKey)
		{
			animator.SetTrigger("idle");
		}
	}
}
