﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button startGame;

	// Use this for initialization
	void Start () {
        startGame.onClick.AddListener(startGamePressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void startGamePressed(){ //LOADS LEVEL ONE
        SceneManager.LoadScene(1);
    }
}
