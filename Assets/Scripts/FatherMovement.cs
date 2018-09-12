using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherMovement : MonoBehaviour {

    //int habilityCounter = 0;
    public bool activatePlatform;


    //for the movement swap
    GeneralPlayerMovement gpm;
    int controls;

    private void Start()
    {
        gpm = GetComponent<GeneralPlayerMovement>();
        controls = gpm.Controls;
    }

    // Update is called once per frame
    void Update ()
    {
        MagicPower();
	}

    void MagicPower()
    {
        if (controls == 0)
        {
            if (Input.GetButtonDown("AbilityA 01"))
            {
                if (!activatePlatform)
                    activatePlatform = true;
                else
                    activatePlatform = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("AbilityB 01"))
            {
                if (!activatePlatform)
                    activatePlatform = true;
                else
                    activatePlatform = false;
            }
        }

    }
}
