using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBox : MonoBehaviour {
    private FatherMovement player;
    private GameObject playerObject;

    private Collider2D colision;
    private MeshRenderer view;

    public char magicPlatformType = 'A'; // A default value // if it is A it will begin banish
    //B in case of platforms that start on the scene

	// Use this for initialization
	void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<FatherMovement>();

        colision = GetComponent<Collider2D>();
        view = GetComponent<MeshRenderer>();

        if(magicPlatformType == 'A')
        {
            colision.enabled = false;
            view.enabled = false;
        }
        else
        {
            colision.enabled = true;
            view.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (player.activatePlatform)
        {

            if (magicPlatformType == 'A') // if player activate the power 'A' platforms will apear
            {                                                           //'B' platforms will banish

                colision.enabled = true;
                view.enabled = true;
            }
            else
            {
                colision.enabled = false;
                view.enabled = false;
            }
        }
        else 
        {
            if (magicPlatformType == 'A') // if player desactivate the power 'A' platforms will banish
            {                                                               //'B' platforms will apear
                colision.enabled = false;
                view.enabled = false;
            }
            else
            {
                colision.enabled = true;
                view.enabled = true;
            }
        }
    }
}
