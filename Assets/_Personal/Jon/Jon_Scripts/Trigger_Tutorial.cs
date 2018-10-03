using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_Tutorial : MonoBehaviour {

    public bool isPaused;

    public Text tutText;
    private GameObject tutBox;

    // Use this for initialization
    void Start () {
        tutBox = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).gameObject;
        tutText = tutBox.transform.GetChild(0).GetComponent<Text>();
        tutBox.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tutBox.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
