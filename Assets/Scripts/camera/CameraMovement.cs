using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float cSpeed;
    public float cLength;

    public float cameraHight;
    public float cameraZPos = -1;

    public float CameraMoveTime = 1;
    float cameraTimer;

    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraTimer = CameraMoveTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Checking if player is looking up or down
        if (Input.GetAxis("Vertical") != 0)
        {
            // Timer
            if (cameraTimer <= 0)
            {

            }
            else
            {
                cameraTimer -= Time.deltaTime;
            }

        }

        transform.position = new Vector3 (player.position.x, player.position.y + cameraHight, cameraZPos);
	}
}
