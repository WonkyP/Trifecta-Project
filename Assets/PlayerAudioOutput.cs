using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioOutput : MonoBehaviour {

    public bool Walking        = false;
    public bool Grounded       = false;
    public bool Jump           = false;
    public bool SpiritAbilitie = false;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
        if (Walking && Grounded)
        {

        }
	}
}
