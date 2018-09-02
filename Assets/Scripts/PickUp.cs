using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [HideInInspector]
    public bool hasKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Switch"){
            Debug.Log("1");
            if(Input.GetKeyUp(KeyCode.Space)){
                Debug.Log("2");
                GameObject switchLever = collision.gameObject;
                switchLever.GetComponent<Lever>().interactWithSwitch();

            }
        }
    }
}
