using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour {
    public Canvas gameOverScreen;
    public Image redImage;
	// Use this for initialization
	void Start () {
        
        StartCoroutine(flash());

		
	}
	
    IEnumerator flash(){
       // redImage.CrossFadeAlpha(1f, .3f, true);
        float alpha = 0f;
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                if (j == 0 || j == 2)
                {
                    alpha += .1f;
                }else{
                    alpha -= .1f;
                }
                redImage.color = new Color(redImage.color.r, redImage.color.g, redImage.color.b, alpha);
                yield return new WaitForSecondsRealtime(.03f);
            }
        }
      

        Instantiate(gameOverScreen);
        Destroy(gameObject);
    }

}

