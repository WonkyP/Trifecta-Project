﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollEnemy : MonoBehaviour {

    // Use this for initialization
    public Transform viewOrigin;
    public Transform feetOrigin;
    public float viewRange;
    public float feetRange;
    public float vel;
    private Vector2 dir = new Vector2(1, 0);

    private Rigidbody2D rb;
    //private BoxCollider2D myOwnCollider

    

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        //myOwnCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(viewOrigin.position, dir*viewRange);
        Debug.DrawRay(feetOrigin.position, dir * feetRange);

        RaycastHit2D viewHit = Physics2D.Raycast(viewOrigin.position, dir , viewRange);
        RaycastHit2D feetHit = Physics2D.Raycast(feetOrigin.position, dir, feetRange);

        if (viewHit)
        {
            if(viewHit) // here are going to be the conditions if we want another behaviour for the enemy it it collides with another object
            {
                Flip();
                vel = -vel;
                dir = -dir;
            }
        }

        if (!feetHit)
        {
            Flip();
            vel = -vel;
            dir = -dir;
        }

        if (viewHit)
        {
            if(viewHit.collider.gameObject.tag == "Player")
            {
                if (viewHit.collider.gameObject.GetComponent<SpiritNewMovement>().enabled) {
                    viewHit.collider.gameObject.GetComponent<SpiritNewMovement>().damaged();
                }else if (viewHit.collider.gameObject.GetComponent<DaughterMovement>().enabled)
                {

                }else if (viewHit.collider.gameObject.GetComponent<FatherNewMovement>().enabled)
                {

                }
            }
        }
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector2(vel, rb.velocity.y );
    }

    void Flip()
    {
        Vector3 objectScale = transform.localScale;

        objectScale.x = -objectScale.x;

        transform.localScale = objectScale;
    }
}
