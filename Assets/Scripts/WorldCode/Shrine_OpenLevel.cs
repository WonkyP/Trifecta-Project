using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine_OpenLevel : MonoBehaviour {

    private GameObject Rune01;
    private GameObject Rune02;
    private GameObject Rune03;
    private GameObject GodHaze;
   
    // unlock abilities
    [Header("Ability unlock")]
    public string PowerUnlockID = "X";



    // Use this for initialization
    void Start ()
    {
        Rune01 = gameObject.transform.GetChild(0).gameObject;
        Rune01.SetActive(false);
        Rune02 = gameObject.transform.GetChild(1).gameObject;
        Rune02.SetActive(false);
        Rune02 = gameObject.transform.GetChild(2).gameObject;
        Rune03.SetActive(false);
        GodHaze = gameObject.transform.GetChild(3).gameObject;
        GodHaze.SetActive(false);

        //unlock
        if (PowerUnlockID != "X")
        {
            PlayerPrefs.SetInt(PowerUnlockID, 1);
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            p.SendMessage("GiveAbbility");
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
		
    }
}
