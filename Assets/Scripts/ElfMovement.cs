using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfMovement : MonoBehaviour
{
    // Carl was here!
    public float JumpForce = 5;
    private Rigidbody2D rb;
    private bool jumping = false;
    public float lengthOfTheRayCast;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && jumping == false)
        {
            jumping = true; // just a safe gard to make sure that double jumps never happens
            Jump();
        }
    }

    void Jump() { 

            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), lengthOfTheRayCast, 9/*Ignores the player layer*/); // create the raycast
            if (hit != false) // checks if the raycast hits anything
            {
                print(hit.transform.name); // Chacks the name of the object you are jumping on
                Debug.DrawRay(transform.position, new Vector2(0, -lengthOfTheRayCast), Color.green, 0.5f); // Draw the raycast with a green colour

            }
            else
            {
                Debug.DrawRay(transform.position, new Vector2(0, -lengthOfTheRayCast), Color.red, 0.5f); // draw the raycast with a red colour to show that it's not on the floor
                jumping = false;
                return; // You ain't gonna jump son!
            }

            // modifying the velocity of the rigidbody solves a bug that appears using addForce
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.y);
            jumping = false;
    }

}