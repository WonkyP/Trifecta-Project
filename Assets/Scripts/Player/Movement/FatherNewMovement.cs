﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherNewMovement : MonoBehaviour
{

    [Header("Jump Stats")]
    [Range(10,40)]
    public float jumpSpeed = 20;


    // Getting varables
    Rigidbody2D rb;
    Animator anim;

    // Checking if it's grounded
    [Space]
    public bool isGrounded = false;

    [Header("Raycasts")]
    public float hightOfTheRaycast =0.2f;
    public float widthOfTheRaycast = 0.15f;
     LayerMask JumpableLayers;

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

    [Header("FireBall")]
    public bool FireballUnlocked = false;
    // Second ability
    ObjectPooler objectPooler;
    public GameObject firePointRight;
    public GameObject firePointLeft;
    bool facingRight;

    //public int fatherLife = 100;

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

        // setting abilities
        GiveAbbility();
    }
    public void GiveAbbility()
    {
        if (!FireballUnlocked)
        {
            if (PlayerPrefs.GetInt("F01", 0) == 1)
            {
                FireballUnlocked = true;
            }
        }
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
                //Debug.Log("Box without parent attached");
            }
        }

        if (Input.GetButtonDown("AbilityB 02") && FireballUnlocked)
        {
            Debug.Log("I'm here");
            if (gpm.right)
            {
                objectPooler.spawnFromPool("Player_Bullets", firePointRight.transform.position, firePointRight.transform.rotation);
            }
            else
            {
                objectPooler.spawnFromPool("Player_Bullets", firePointLeft.transform.position, firePointLeft.transform.rotation);
            }

            anim.SetTrigger("Attack");
            //Debug.Log("Player shooting");
        }



        //coyote time
        if (isGrounded)
        {
            curCoyoteTime = coyoteTime;

            // ready to jump again
            jumped = false;

            Jump(false);
        }

        else if (!isGrounded && curCoyoteTime > 0)
        {
            Jump(true);

            curCoyoteTime -= Time.deltaTime;
        }


    }

    bool jumped;

    public void Jump(bool Coyoty)
    {

        // THE JUMP SIGNAL
        if (Input.GetButtonDown("Jump"))
        {
            // COYOTY TIME JUMP
            if (Coyoty && !jumped)
            {
                jumped = true;

                // PLAY THE ANIMATION
                anim.SetTrigger("Jump");

                // ACTIVTE THE JUMP
                rb.velocity = Vector2.up * jumpSpeed;

                curCoyoteTime = 0;

            }

            // SINGLE JUMP AKA GROUND JUMP
            else if (isGrounded && !jumped)
            {
                jumped = true;

                // PLAY THE ANIMATION
                anim.SetTrigger("Jump");

                // ACTIVTE THE JUMP
                rb.velocity = Vector2.up * jumpSpeed;
            }
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


        

        if (hitLeft || hitRight)
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);

            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(widthOfTheRaycast, 0), Color.green);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - hightOfTheRaycast), new Vector2(-widthOfTheRaycast, 0), Color.green);
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
        Debug.Log("Hellow");
        if(GameManager.instance != null)
        GameManager.instance.EnableFatherLife();
    }

    public void damaged()
    {
        //fatherLife -= 5;
        GameManager.instance.fatherDamage();
    }
}