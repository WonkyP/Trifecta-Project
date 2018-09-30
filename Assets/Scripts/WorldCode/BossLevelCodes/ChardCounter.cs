using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChardCounter : MonoBehaviour {

    public int StartShards;
    public int curShardCount;

    public GameObject ChardNrObject;
    Text ChardNrText;

    GeneralPlayerMovement GPM;
    int curChar = 4;

    //UI for 0 shards
    public GameObject shardUI;

	// Use this for initialization
	void Start () {

        curShardCount = StartShards;

        GPM = GameObject.FindGameObjectWithTag("Player").GetComponent<GeneralPlayerMovement>();

        curChar = GPM.characterSelected;

        ChardNrText = ChardNrObject.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (curChar != GPM.characterSelected) // checks if the player have a new char activ
        {
            curChar = GPM.characterSelected;
            curShardCount -= 1;

            ChardNrText.text = curShardCount.ToString();

            if (curShardCount <= 0)
            {
                // Disable everything!!!
                GPM.enabled = false; // turns off the GPM
                Time.timeScale = 0; // Time set to 0
                shardUI.SetActive(true); // activate the ui

            }
        }
        
	}

    public void RestartScene()
    {
        // activate everything
        Time.timeScale = 1;
        GPM.enabled = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
