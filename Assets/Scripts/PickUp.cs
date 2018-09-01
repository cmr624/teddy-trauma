using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [HideInInspector]
    public bool hasKey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }
    }
}
