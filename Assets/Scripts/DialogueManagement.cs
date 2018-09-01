using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagement : MonoBehaviour {

    public string text;
    public Canvas speech;
    public Canvas spaceIndication; //this is the little popup to tell the user to press space

    bool talkingEnabled = false;
    bool dialogueUp = false;
    bool restartCoroutine = true;  //used for whether or not to start the coroutine of putting tect on scfreen 
    //when player moves by another toy

    Transform child;
    Text contents;

    private IEnumerator coroutine; //have reference so we can stop the coroutine

	// Use this for initialization
	void Start () {
        speech.enabled = false;
        spaceIndication.enabled = false;
        child = speech.transform.Find("Text");
        contents = child.GetComponent<Text>();
        coroutine = delayedSpeech(contents);
    }

    void Update()
    {
        if(talkingEnabled){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dialogueUp == false)
                {
                    spaceIndication.enabled = false;
                    dialogueUp = true;
                    speech.enabled = true; //show the speech bubble
                    if (restartCoroutine) //if the coroutine hasn't run yet
                    {
                        StartCoroutine(coroutine);
                        restartCoroutine = false;
                    }
                    else
                    {
                        contents.text = text;
                    }
                }
                else{
                    spaceIndication.enabled = true;
                    dialogueUp = false;
                    speech.enabled = false; //turn off the spech bubble
                    StopCoroutine(coroutine); //stop the typing!
                    contents.text = text;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        talkingEnabled = true;
        spaceIndication.enabled = true;

    }
    void OnTriggerExit2D(Collider2D col)
    {
        talkingEnabled = false;
        speech.enabled = false;
        spaceIndication.enabled = false;
    }

    IEnumerator delayedSpeech(Text contents){ //make the text appear letter by letter
        char[] c = text.ToCharArray();
        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(.05f); //time inbetween characters appearing on screen
            contents.text = contents.text + c[i];
        }
        contents.text = text;
    }
}
