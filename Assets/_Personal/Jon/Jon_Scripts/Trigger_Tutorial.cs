using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_Tutorial : MonoBehaviour {

    public bool isPaused;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
