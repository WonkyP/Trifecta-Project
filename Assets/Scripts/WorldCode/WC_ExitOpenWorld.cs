using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WC_ExitOpenWorld : MonoBehaviour {

    public string SceneName; // we have to set the scene name

    bool entryGrantet = false;

    public string NameOfTheExitObject;

    public int EntryCost;
	
	void Update () {
        if (entryGrantet)
        {
            if (Input.GetButtonDown("Interact") && Time.timeScale != 0) // Currently set to E on the keyboard.
            {
                if (PlayerPrefs.GetInt(SceneName,0) == 1)
                {
                    //print("YOU MAY PASS");
                    GameObject.FindGameObjectWithTag("DoorNr").GetComponent<DoNotDestroy>().NameOfTheObject = NameOfTheExitObject; // set the exit object

                    SceneManager.LoadScene(SceneName); // load the next scene
                    return;
                }

                if (PlayerPrefs.GetInt("SoulShards", 0) >= EntryCost)
                {
                    PlayerPrefs.SetInt(SceneName, 1);

                    int cur = PlayerPrefs.GetInt("SoulShards", 0);
                    cur -= EntryCost;
                    PlayerPrefs.SetInt("SoulShards", cur);

                    //print("YOU MAY PASS");
                    GameObject.FindGameObjectWithTag("DoorNr").GetComponent<DoNotDestroy>().NameOfTheObject = NameOfTheExitObject; // set the exit object

                    SceneManager.LoadScene(SceneName); // load the next scene
                }



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

