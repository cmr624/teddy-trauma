using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public KeyCode restartButton = KeyCode.R;
    public static LevelManager Instance { get; private set; }

	// Use this for initialization
	void Start () {
        Instance = this;
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        Time.timeScale = 0f;
        // Nina puts up a screen here
        // Press "R" to restart
        StartCoroutine(ListenForRestart());
    }
    IEnumerator ListenForRestart()
    {
        while (true)
        {
            if (Input.GetKeyDown(restartButton))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                yield break;
            }
            yield return null;
        }
    }
}
