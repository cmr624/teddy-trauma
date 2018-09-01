using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public Button menuButton;
    public Button restartLevel;
    public Button quitButton;
    public GameObject menuPopup;

    bool menuUp = false;

	// Use this for initialization
	void Start () {
        menuButton.onClick.AddListener(menuPressed);
        restartLevel.onClick.AddListener(restartPressed);
        quitButton.onClick.AddListener(quitPressed);
	}

    void menuPressed(){ //pull the menu up if it wasn't up already
        if(menuUp){
            //put it down
            StartCoroutine(moveMenu(-8f));
            menuUp = false;

        }else{
            //pull it up
            StartCoroutine(moveMenu(8f));
            menuUp = true;
        }
    }

    void restartPressed(){ //reload the scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
       
    }

    void quitPressed(){ //go back to the main menu
        SceneManager.LoadScene(0);
    }

    IEnumerator moveMenu(float distance){
        menuButton.interactable = false;
        for (int i = 0; i < 8;i++){
            menuPopup.transform.localPosition = new Vector3(menuPopup.transform.localPosition.x, menuPopup.transform.localPosition.y + distance, menuPopup.transform.localPosition.z);
            yield return new WaitForSeconds(.02f);
        }
        menuButton.interactable = true;
    }
}
