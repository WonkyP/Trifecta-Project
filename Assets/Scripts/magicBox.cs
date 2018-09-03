using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBox : MonoBehaviour {
    private MagicMovement player;
    private GameObject playerObject;

    //private Collider2D colision;
    private MeshRenderer view;

	// Use this for initialization
	void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<MagicMovement>();

        //colision = GetComponent<Collider2D>();
        view = GetComponent<MeshRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (player.activatePlatform)
        {
            //colision.enabled = true;
            view.enabled = true;
        }
        else
        {
            //colision.enabled = false;
            view.enabled = false;
        }
    }
}
