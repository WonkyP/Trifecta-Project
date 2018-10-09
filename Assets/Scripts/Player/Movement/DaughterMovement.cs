﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaughterMovement : MonoBehaviour
{
    [Header("Jump Stats")]
    public float jumpSpeed = 12;
    public int airJumpCount = 1;
    int curAirJumpCount;


    [Header("Jump from the ground")]
    public float airTime;
    float curAirTime; // this var will change over time

    [Header("Jump without ground")]
    public float DoubleJumpSpeed = 12;
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
    public LayerMask JumpableLayers;

    [Space]
    public float yVel;

    [Space]
    public float coyoteTime;
    float curCoyoteTime;
    bool jumping = false;


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

        //coyote time
        if (jumping == false)
        {

            if (isGrounded)
            {
                curAirJumpCount = airJumpCount;
                curCoyoteTime = coyoteTime;
            }

            else if (!isGrounded && curCoyoteTime > 0)
            {
                curCoyoteTime -= Time.deltaTime;

                Jump();

            }
            else if (curCoyoteTime <= 0)
            {
            }
        }


        Jump();

    }

    public void Jump()
    {
        // Jumping
        if (Input.GetButtonUp("Jump") && jumping == true)// && curAirTime > 0) // jump over
        {
            curAirTime = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 4);

            jumping = false;
        }
        else if (Input.GetButtonDown("Jump") && curCoyoteTime > 0) // take Off
        {
            jumping = true;
            curCoyoteTime = 0;


            curVel = jumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = airTime; // set how long the button press will be for
            return;
        }
        else if (Input.GetButton("Jump") && curAirTime > 0) // In The Air
        {
            curAirTime -= Time.deltaTime;

            curVel = curVel - Time.deltaTime * 20;

            rb.velocity = new Vector2(rb.velocity.x, curVel);
            return;
        }
        //////////////////////////////////////////////////////// X2!!!!
        if (Input.GetButtonDown("Jump") && curAirJumpCount > 0) // checks if the player tries to jump in the air
        {
            curAirJumpCount -= 1;

            jumping = true;

            curVel = DoubleJumpSpeed; // set the vel

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
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(1, 0), widthOfTheRaycast, JumpableLayers/*Ignores the player layer*/);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(-1, 0), widthOfTheRaycast, JumpableLayers/*Ignores the player layer*/);
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

    private void OnEnable()
    {
        curCoyoteTime = 0;

    }

}