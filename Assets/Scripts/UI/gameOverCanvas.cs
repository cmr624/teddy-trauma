using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverCanvas : MonoBehaviour {
    public Button retry;
    public Button quit;

	// Use this for initialization
	void Start () {
        retry.onClick.AddListener(retryPressed);
        quit.onClick.AddListener(quitPressed);
		
	}

    void retryPressed(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    void quitPressed(){
        SceneManager.LoadScene("MainMenu");

    }
}
