using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daddy : MonoBehaviour {

    public static daddy Instance { get; private set; }
	// Use this for initialization
	void Awake () {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
