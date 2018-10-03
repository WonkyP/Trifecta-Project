using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Header("Defult Camera Pos")]
    public float cameraHight;
    public float cameraZPos = -1;

    [Header("Camera stats")]
    public float cSpeed;

    public float CameraMoveTime = 1;
    float cameraTimer;

    Transform player;
    GeneralPlayerMovement GMP;

    public float LookDistance;
    Vector3 p;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GMP = player.GetComponent<GeneralPlayerMovement>();

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
                // checks the YVal
                // stops if from happening while moving too much
                if (Input.GetAxis("Vertical") >= 0 && Input.GetAxis("Horizontal") <= 0.1 && Input.GetAxis("Horizontal") >= -0.1 && GMP.velY == 0)
                {
                    // UP
                    p = new Vector3(player.position.x, player.position.y + cameraHight + LookDistance, cameraZPos);

                    MovingTheCamera(p);

                    return;
                }
                // stops if from happening while moving too much
                else if (Input.GetAxis("Vertical") <= 0 && Input.GetAxis("Horizontal") <= 0.1 && Input.GetAxis("Horizontal") >= -0.1 && GMP.velY == 0)
                {
                    // Down
                    p = new Vector3(player.position.x, player.position.y + cameraHight - LookDistance, cameraZPos);
                    MovingTheCamera(p);

                    return;
                }
            }
            // counts down
            else
            {
                cameraTimer -= Time.deltaTime;
            }

        }
        // Resets the timer for looking up
        else if(cameraTimer != CameraMoveTime)
        {
            cameraTimer = CameraMoveTime;
        }

        // defult camera target
        p = new Vector3(player.position.x, player.position.y + cameraHight, cameraZPos);
        MovingTheCamera(p);

	}


    public void MovingTheCamera(Vector3 target)
    {
        transform.position = Vector3.Lerp(transform.position, target, Vector3.Distance(transform.position, target) * cSpeed * Time.deltaTime);
            //new Vector3(player.position.x, player.position.y + cameraHight, cameraZPos);
    }
}

