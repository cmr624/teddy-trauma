using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagement : MonoBehaviour {

    public string text;
    public Canvas speech;

    bool restartCoroutine = true; 

    Transform child;
    Text contents;

    private IEnumerator coroutine; //have reference so we can stop the coroutine

	// Use this for initialization
	void Start () {
        speech.enabled = false;
        child = speech.transform.Find("Text");
        contents = child.GetComponent<Text>();
        coroutine = delayedSpeech(contents);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        speech.enabled = true; //show the speech bubble
        if (restartCoroutine)
        {
            StartCoroutine(coroutine);
            restartCoroutine = false;
        }
        else{
            contents.text = text;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        speech.enabled = false; //turn off the spech bubble
        StopCoroutine(coroutine);
        contents.text = text;

    }

    IEnumerator delayedSpeech(Text contents){ //make the text appear letter by letter
        char[] c = text.ToCharArray();
        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(.03f); //time inbetween characters appearing on screen
            contents.text = contents.text + c[i];
        }
        contents.text = text;

    }


}
