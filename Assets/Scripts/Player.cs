using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject {

    public bool Detectable { get; private set; }

	protected override void Awake ()
    {
        base.Awake();
	}

    private Vector2 lastFrameInput;
	protected override void LateUpdate()
    {
        base.LateUpdate();


        Vector2 frameInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Stealth
        Detectable = frameInput.magnitude != 0;

        bool wasConstrained;
        frameInput = MoveInDirection(frameInput, out wasConstrained);

        if (wasConstrained == false)
        {
            MoveInDirection(-1 * lastFrameInput);
        }

        lastFrameInput = frameInput;
        Debug.Log("This frame: " + lastFrameInput);
	}
}
