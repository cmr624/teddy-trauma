using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject {

    public bool Detectable { get; private set; }

	protected override void Start ()
    {
        base.Start();
	}

    private Vector2 lastFrameInput;
	protected override void Update()
    {
        base.Update();

        MoveInDirection(-1 * lastFrameInput);

        Vector2 frameInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Detectable = frameInput.magnitude != 0;

        MoveInDirection(frameInput);
        lastFrameInput = frameInput;
	}
}
