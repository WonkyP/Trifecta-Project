using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirePoint : MonoBehaviour {

    GeneralPlayerMovement gpm;

	// Use this for initialization
	void Start () {
        gpm = GameObject.Find("Player").GetComponent<GeneralPlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gpm.changeDir)
        {
            Flip();
            gpm.changeDir = false;
        }
	}

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
