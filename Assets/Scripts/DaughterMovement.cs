using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaughterMovement : MonoBehaviour
{
    [Header("Jump Stats")]
    public float jumpSpeed = 10;
    public int airJumpCount = 1;
    int curAirJumpCount;


    [Header("Jump from the ground")]
    public float airTime;
    public float curAirTime; // this var will change over time

    [Header("Jump without ground")]
    public float DoubleJumpAirTime;


    // Getting varables
    Rigidbody2D rb;

    // Checking if it's grounded
    [Space]
    public bool isGrounded = false;

    [Header("Raycasts")]
    public bool drawRaycast = false;
    public float hightOfTheRaycast;
    public float widthOfTheRaycast;



    [Space]
    public float yVel;

    //[Header("")]
    public void Start()
    {

        // setting vars
        rb = GetComponent<Rigidbody2D>();
    }

    float curVel;


    public void Update()
    {
        GroundCheck();
        if (Input.GetButtonUp("Jump") && curAirTime > 0) // jump over
        {
            curAirTime = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 4);
        }
        else if (Input.GetButtonDown("Jump") && isGrounded) // take Off
        {
            curAirJumpCount = airJumpCount;

            curVel = jumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = airTime; // set how long the button press will be for
            return;
        }
        else if (Input.GetButton("Jump") && curAirTime > 0) // In The Air
        {
            curAirTime -= Time.deltaTime;

            curVel = curVel - Time.deltaTime * 5;

            rb.velocity = new Vector2(rb.velocity.x, curVel);
            return;
        }
        //////////////////////////////////////////////////////// X2!!!!
        else if (Input.GetButtonDown("Jump") && curAirJumpCount > 0 && !isGrounded) // checks if the player tries to jump in the air
        {
            curAirJumpCount -= 1;

            curVel = jumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = DoubleJumpAirTime; // set how long the button press will be for
            return;
        }

    }

    public void FixedUpdate()
    {
        yVel = rb.velocity.y;
        Gravity();
    }


    public void Gravity()
    {
        if (yVel < 0)
        {
            rb.gravityScale = 4;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    public void GroundCheck()
    {
        // check if player is grounded 
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(1, 0), widthOfTheRaycast, 9/*Ignores the player layer*/);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(-1, 0), widthOfTheRaycast, 9/*Ignores the player layer*/);
        if (drawRaycast)
        {
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(widthOfTheRaycast, 0), Color.green, 0.5f);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(-widthOfTheRaycast, 0), Color.green, 0.5f);
        }

        if (hitLeft || hitRight)
        {
            isGrounded = true;
        }
        else if (isGrounded)
        {
            isGrounded = false;
        }
    }

















































    //[Header("Jumping")]
    //public float JumpForce = 5;
    //public float DoubleJumpForce = 5;
    //private Rigidbody2D rb;
    //bool jumping = false;
    //public float lengthOfTheRayCast;
    //public float widthOfTheRayCast;
    //public float AirJumpTime;
    //float curAirJumpTime;
    //bool jumpable = false;
    ////Air Jumps
    //public int airJumpAmount;
    //int curJump = 0;
    //// Safe jumping
    //public float coyoteTime;
    //float curSafeJumpTime = 0;

    //GeneralPlayerMovement gpm;
    //int controlNr;


    //// Use this for initialization
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    gpm = GetComponent<GeneralPlayerMovement>();
    //    controlNr = gpm.Controls;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    // Checking if the char are grounded and or have a air jump
    //    CheckJump();

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        // The char jump once
    //        Jump();
    //    }
    //}

    //void CheckJump()
    //{
    //    // check if theres any ground near the player's feet
    //    RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(1, 0), widthOfTheRayCast, 9/*Ignores the player layer*/);
    //    RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(-1, 0), widthOfTheRayCast, 9/*Ignores the player layer*/);

    //    if (hitRight == true || hitLeft == true) // checks if the raycast hits anything
    //    {
    //        curJump = airJumpAmount;
    //        if (jumping) // currently jumping
    //        {
    //            //Set the timer for the next jump here
    //            if (curAirJumpTime > 0)
    //            {
    //                curAirJumpTime -= Time.deltaTime;
    //            }else
    //            {
    //                jumping = false;
    //                curAirJumpTime = AirJumpTime;
    //            }
    //            jumpable = false;
    //            return;
    //        }
    //        else
    //        {
    //            jumpable = true;
    //        }
    //        // debugs for left and right
    //        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(widthOfTheRayCast, 0), Color.green, 0.5f);
    //        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - lengthOfTheRayCast), new Vector2(-widthOfTheRayCast, 0), Color.green, 0.5f);
    //    }
    //    else if (jumping == false)
    //    {
    //        if (curSafeJumpTime < 0) // checks if the time for jump is still not out
    //        {
    //            jumping = true;
    //            curSafeJumpTime = coyoteTime;
    //        }
    //        else
    //        {
    //            curSafeJumpTime -= Time.deltaTime;
    //        }

    //        Debug.DrawRay(transform.position, new Vector2(0, -lengthOfTheRayCast), Color.red, 0.5f); // draw the raycast with a red colour to show that it's not on the floor

    //    }
    //    else
    //    {
    //        jumping = true;
    //    }
    //}

    //void Jump() {


    //    if (jumpable && jumping == false)
    //    {
    //        jumping = true;
    //        curAirJumpTime = AirJumpTime;
    //        jumpable = false;

    //        // modifying the velocity of the rigidbody solves a bug that appears using addForce
    //        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.y);
    //    }
    //    else if (curJump > 0)
    //    {
    //        curJump -= 1;
    //        // modifying the velocity of the rigidbody solves a bug that appears using addForce
    //        rb.velocity = new Vector3(rb.velocity.x, DoubleJumpForce, rb.velocity.y);
    //    }


    //}

}