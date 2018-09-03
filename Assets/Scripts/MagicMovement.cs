using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMovement : MonoBehaviour {

    //int habilityCounter = 0;
    public bool activatePlatform;
	
	// Update is called once per frame
	void Update ()
    {
        MagicPower();
	}

    void MagicPower()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (!activatePlatform)
                activatePlatform = true;
            else
                activatePlatform = false;
        }
    }
}
