using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_Tutorial : MonoBehaviour {

    public Text tutText;
    public string textToDisplay;
    private GameObject tutBox;
    private Button tutBoxButton;
    // Use this for initialization

    void Start () {
        //Trigger is finding references in the canvas to store, then deactivating the tutorial box. There must be Canvas_Menu prefab in the scene hierarchy.
        tutBox = GameObject.FindGameObjectWithTag("Canvas_Main").transform.GetChild(2).gameObject;
        tutText = tutBox.transform.GetChild(0).GetComponent<Text>();
        tutBoxButton = tutBox.transform.GetChild(1).GetComponent<Button>();
        tutBox.SetActive(false);

    }

    //When player enters trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {   
            //Activates tutorial box and displays text as input from trigger gameObject in inspector. Stops time.
            tutBox.SetActive(true);
            tutText.text = textToDisplay;
            //Adds button functionality to the button in the tutorial box.
            tutBoxButton.onClick.AddListener(OKbutton);
            Time.timeScale = 0;
        }
    }

    //Button function in tutorial box.
    public void OKbutton()
    {
        //Deactivate tutorial box and resume time.
        tutBox.SetActive(false);
        Time.timeScale = 1;
        //Destroy the trigger from the scene.
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
