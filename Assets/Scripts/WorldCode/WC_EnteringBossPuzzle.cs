using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WC_EnteringBossPuzzle : MonoBehaviour {

    public string SceneName; // we have to set the scene name

    bool entryGrantet = false;

    public string NameOfTheExitObject;

    [Header("UI")]
    public GameObject uiCanvus;

	void Update () {
        if (entryGrantet)
        {
            if (Input.GetButtonDown("Interact") && Time.timeScale != 0) // Currently set to E on the keyboard.
            {
                //print("YOU MAY PASS");
                GameObject.FindGameObjectWithTag("DoorNr").GetComponent<DoNotDestroy>().NameOfTheObject = NameOfTheExitObject; // set the exit object

                SceneManager.LoadScene(SceneName); // load the next scene
            }
            
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // checks what layer the triggering object is and activates if it's the "Player" layer
        {
            entryGrantet = true;
            uiCanvus.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // checks what layer the triggering object is and deactivates if it's the "Player" layer
        {
            entryGrantet = false;
            uiCanvus.SetActive(false);

        }
    }

}

