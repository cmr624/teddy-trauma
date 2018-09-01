using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(fading());
    }

    IEnumerator fading()
    {
        yield return new WaitForSeconds(4f);
  
        Destroy(gameObject);
    }

}
