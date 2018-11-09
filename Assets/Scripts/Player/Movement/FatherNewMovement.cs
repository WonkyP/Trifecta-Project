﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherNewMovement : MonoBehaviour
{

    [Header("Jump Stats")]
    public float jumpSpeed = 14;
    public int airJumpCount = 0;
    int curAirJumpCount;


    [Header("Jump from the ground")]
    public float airTime = 0.3f;
    float curAirTime; // this var will change over time

    [Header("Jump without ground")]
    public float DoubleJumpAirTime = 0;


    // Getting varables
    Rigidbody2D rb;
    Animator anim;

    // Checking if it's grounded
    [Space]
    public bool isGrounded = false;

    [Header("Raycasts")]
    public bool drawRaycast = false;
    public float hightOfTheRaycast =0.2f;
    public float widthOfTheRaycast = 0.15f;
    public LayerMask JumpableLayers;

    [Space]
    public float yVel;
    float curVel;


    [Space]
    public float coyoteTime = 0.2f;
    float curCoyoteTime;
    bool jumping = false;


    // Box
    RaycastHit2D rightHit;
    RaycastHit2D leftHit;
    GameObject box;
    private GeneralPlayerMovement gpm;
    Transform parent;

    // Second ability
    ObjectPooler objectPooler;
    public GameObject firePointRight;
    public GameObject firePointLeft;
    bool facingRight;

    //[Header("")]
    public void Start()
    {
        JumpableLayers = LayerMask.GetMask("Ground", "WallJump", "Default");
        // setting vars
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gpm = GetComponent<GeneralPlayerMovement>();
        objectPooler = ObjectPooler.instance;
        facingRight = gpm.right;
    }



    public void Update()
    {
        GroundCheck();



        // THE BOCK MOVEMENT
        if (Input.GetButton("AbilityB 01") && NextToBox())
        {
            if (rightHit)
                box = rightHit.collider.gameObject;
            else if (leftHit)
                box = leftHit.collider.gameObject;

            parent = box.transform.parent;
            box.transform.parent = transform;
        }
        else if (Input.GetButtonUp("AbilityB 01") || !NextToBox())
        {
            try
            {
                box.transform.parent = null;
            }
            catch
            {
                Debug.Log("Box without parent attached");
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            if(gpm.right)
                objectPooler.spawnFromPool("Player_Bullets", firePointRight.transform.position, firePointRight.transform.rotation);
            else
                objectPooler.spawnFromPool("Player_Bullets", firePointLeft.transform.position, firePointLeft.transform.rotation);

            //Debug.Log("Player shooting");
        }



        //coyote time
        if (jumping == false)
        {

            if (isGrounded)
            {
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


        if (Input.GetButton("AbilityB 02")){
            Debug.Log("LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOL");
        }


    }

    public void Jump()
    {
 
        // Jumping
        if (Input.GetButtonUp("Jump") && jumping == true)// && curAirTime > 0) // jump over
        {
            curAirTime = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 4);
            jumping = false;

            //anim.SetBool("Jump", false);
            anim.SetBool("DoubleJump", false);
        }
        else if (Input.GetButtonDown("Jump") && curCoyoteTime > 0) // take Off
        {
            jumping = true;
            curCoyoteTime = 0;

            curAirJumpCount = airJumpCount;
            curVel = jumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = airTime; // set how long the button press will be for

            anim.SetTrigger("Jump");
            print("PLAYER JUMPED");

            return;
        }
        else if (Input.GetButton("Jump") && curAirTime > 0) // In The Air
        {
            curAirTime -= Time.deltaTime;

            curVel = curVel - Time.deltaTime * 20;

            rb.velocity = new Vector2(rb.velocity.x, curVel);

            //anim.SetBool("Jump", false);
            anim.SetBool("DoubleJump", false);
            return;
        }
        //////////////////////////////////////////////////////// X2!!!!
        if (Input.GetButtonDown("Jump") && curAirJumpCount > 0) // checks if the player tries to jump in the air
        {
            curAirJumpCount -= 1;

            jumping = true;

            curVel = jumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = DoubleJumpAirTime; // set how long the button press will be for


            return;
        }


    }

    public void FixedUpdate()
    {
        yVel = rb.velocity.y;
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
            anim.SetBool("isGrounded", true);


        }
        else if (isGrounded)
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

    bool NextToBox()
    {
        bool b = false;

        //if (script.right)
        rightHit = Physics2D.Raycast(transform.position + new Vector3(transform.lossyScale.x / 2 + 0.4f, 0.5f, 0.0f), Vector2.right * transform.localScale.x, 1.0f);
        //else
        leftHit = Physics2D.Raycast(transform.position - new Vector3(transform.lossyScale.x / 2 + 0.4f, -0.5f, 0.0f), Vector2.left * transform.localScale.x, 1.0f);


        if (rightHit.collider != null)
        {
            if (rightHit.collider.gameObject.tag == "Box")
                b = true;
        }
        else if (leftHit.collider != null)
        {
            if (leftHit.collider.gameObject.tag == "Box")
                b = true;
        }
        else
        {
            b = false;
        }

        return b;
    }

    void Flip()
    {
        facingRight = !facingRight;
        //transform.Rotate(0f, 180f, 0f);
    }


    private void OnDisable()
    {
        if (box != null)
            if (box.transform.parent != null)
                box.transform.parent = parent;
    }


    private void OnEnable()
    {
        curCoyoteTime = 0;

    }
}