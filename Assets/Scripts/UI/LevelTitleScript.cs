using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTitleScript : MonoBehaviour {
    public Text text;
    public Image image;

	// Use this for initialization
	void Start () {
        StartCoroutine(fading());
    }

    IEnumerator fading(){
        yield return new WaitForSeconds(1f);
        fade();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    void fade(){
        Color colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        image.CrossFadeColor(colorToFadeTo, 1f, true, true);
        text.CrossFadeColor(colorToFadeTo, 1f, true, true);
    }

}
