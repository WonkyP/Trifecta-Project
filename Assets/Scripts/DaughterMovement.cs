using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaughterMovement : MonoBehaviour
{
    // Carl was here!
    public float JumpForce = 5;
    private Rigidbody2D rb;
    bool jumping = false;
    public float lengthOfTheRayCast;
    public float widthOfTheRayCast;
    public float AirJumpTime;
    float curAirJumpTime;
    bool jumpable = false;
    //Air Jumps
    public int airJumpAmount;
    int curJump = 0;
    // Saf jumping
    public float coyoteTime;
    float curSafeJumpTime = 0;

    GeneralPlayerMovement gpm;
    int controlNr;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gpm = GetComponent<GeneralPlayerMovement>();
        controlNr = gpm.Controls;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlNr == 0) // X Y B
        {
            if (Input.GetButtonDown("AbilityA 01"))// && jumping == false)
            {
                //jumping = true; // just a safe gard to make sure that double jumps never happens
                Jump();
            }
        }
        else // LB and RB
        {
            if (Input.GetButtonDown("AbilityB 01"))// && jumping == false)
            {
                //jumping = true; // just a safe gard to make sure that double jumps never happens
                Jump();
            }
        }

        CheckJump();
    }

    void CheckJump()
    {

        // check if theres any ground near the player's feet
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(1, 0), widthOfTheRayCast, 9/*Ignores the player layer*/);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(-1, 0), widthOfTheRayCast, 9/*Ignores the player layer*/);


        if (hitRight == true || hitLeft == true) // checks if the raycast hits anything
        {
            curJump = airJumpAmount;
            if (jumping) // currently jumping
            {
                //Set the timer for the next jump here
                if (curAirJumpTime > 0)
                {
                    curAirJumpTime -= Time.deltaTime;
                }else
                {
                    jumping = false;
                    curAirJumpTime = AirJumpTime;
                }

                /////
                jumpable = false;
                return;
            }
            else
            {
                jumpable = true;
            }
            // debugs for left and right
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(widthOfTheRayCast, 0), Color.green, 0.5f);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(-widthOfTheRayCast, 0), Color.green, 0.5f);
        }
        else if (jumping == false)
        {

            if (curSafeJumpTime < 0) // checks if the time for jump is still not out
            {
                jumping = true;
                curSafeJumpTime = coyoteTime;
;

            }
            else
            {
                curSafeJumpTime -= Time.deltaTime;
            }

            Debug.DrawRay(transform.position, new Vector2(0, -lengthOfTheRayCast), Color.red, 0.5f); // draw the raycast with a red colour to show that it's not on the floor

        }
        else
        {
            jumping = true;
        }
    }

    void Jump() {


        if (jumpable && jumping == false)
        {
            jumping = true;
            curAirJumpTime = AirJumpTime;
            jumpable = false;

            // modifying the velocity of the rigidbody solves a bug that appears using addForce
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.y);
            //jumping = false;
        }
        else if (curJump > 0)
        {
            curJump -= 1;
            // modifying the velocity of the rigidbody solves a bug that appears using addForce
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.y);
        }


    }

}