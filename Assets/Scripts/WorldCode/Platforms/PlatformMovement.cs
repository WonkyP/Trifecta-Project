using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public Vector2 initPos;
    public float movements;
    public bool action;
    public char movementKind = 'v';
     
	// Use this for initialization
	void Start () {
        initPos = this.transform.position;
        action = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(action)
        if (movementKind == 'v')
        {
            if (transform.position.y < initPos.y + movements) {
                float newPosY = transform.position.y + 0.01f;
                transform.position = new Vector2(transform.position.x, newPosY);
            }
        }
        else if(movementKind == 'h')
        {

        }
	}
}
