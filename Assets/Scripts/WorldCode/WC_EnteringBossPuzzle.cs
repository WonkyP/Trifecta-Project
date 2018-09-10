﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WC_EnteringBossPuzzle : MonoBehaviour {

    public int sceneIndexNumber; // we have to set the scene index our self :(
    bool entryGrantet = false;

    public string NameOfTheExitObject;
	
	void Update () {
        if (entryGrantet)
        {
            if (Input.GetButtonDown("Fire1")) // Currently set to E on the keyboard.
            {
                print("YOU MAY PASS");
                GameObject.FindGameObjectWithTag("DoorNr").GetComponent<DoNotDestroy>().NameOfTheObject = NameOfTheExitObject; // set the exit object

                SceneManager.LoadScene(sceneIndexNumber); // load the next scene
            }
            
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // checks what layer the triggering object is and activates if it's the "Player" layer
        {
            entryGrantet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // checks what layer the triggering object is and deactivates if it's the "Player" layer
        {
            entryGrantet = false;
        }
    }

}

