using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAnimation : MonoBehaviour {

    public bool left;

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("moveLeft",left);
	}
    void setLeft(){
        left = true;
    }
}
