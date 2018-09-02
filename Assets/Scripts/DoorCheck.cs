using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCheck : MonoBehaviour {

    public string NextLevelName;
    public bool locked;
	// Use this for initialization
	void Start () {
		
	}
	
	// LateUpdate is called once per frame
	void LateUpdate () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (locked)
            {
                if (collision.gameObject.GetComponent<PickUp>().hasKey)
                {
                    //YOU WIN THIS LEVEL
                    SceneManager.LoadScene(NextLevelName);
                    Debug.Log("UNLOCKED");
                }
                else
                {
                    Debug.Log("LOCKED");
                }
            }
            else{
                SceneManager.LoadScene(NextLevelName);
                Debug.Log("UNLOCKED");
            }
        }
    }
}
