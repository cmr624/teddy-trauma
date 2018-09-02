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

        MoveInDirection(-1 * lastFrameInput);

        Vector2 frameInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Stealth
        Detectable = frameInput.magnitude != 0;

        lastFrameInput = MoveInDirection(frameInput);

        Debug.Log("This frame: " + lastFrameInput);
	}
}
