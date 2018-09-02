using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : EnvironmentalObject {

    bool gameOver;
    public Canvas gameOverScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    protected override void ActOnMovableObject(MovableObject obj)
    {
        if (gameOver == false)
        {
            Instantiate(gameOverScreen);
            Time.timeScale = 0f;
        }
    }
}
