using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float cSpeed;
    public float cLength;

    public float cameraHight;
    public float cameraZPos = -1;


    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {


        transform.position = new Vector3 (player.position.x, player.position.y + cameraHight, cameraZPos);
	}
}
