﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayerMovement : MonoBehaviour {
    public int Controls = 0;

    [Header("Daughter Stats")]
    public float dSpeed;

    [Header("Spirit Stats")]
    public float sSpeed;

    [Header("Wizard Stats")]
    public float wSpeed;

    float curSpeed;

    //private Rigidbody2D rb; // a relic from when we used force to move the char
    public bool right = true;

    // A variable for each character to enable and disable each power
    private DaughterMovement c0Script;
    private SpiritMovement c1Script;
    private FatherMovement c2Script;

    // A variable for the animations
    Animator anim;

    // A variable to change the color of the Player wen he changes the character
    //private MeshRenderer render;

    // FOR THE OTHER CONTROLS
    int curActivChar;


    // Use this for initialization
    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();

        // The scripts of the other characters
        c0Script = GetComponent<DaughterMovement>();
        c1Script = GetComponent<SpiritMovement>();
        c2Script = GetComponent<FatherMovement>();


        anim = GetComponent<Animator>();


        curSpeed = dSpeed;
    }

    void Update()
    {
        ChangeCharacter();
    }

    // Update for physics engine
    void FixedUpdate()
    {
        GeneralMovement(); 
    }

    // General movement of the player
    void GeneralMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float SPD = curSpeed * Input.GetAxis("Horizontal"); // set spd to the curspeed and dir the player is walking
            transform.position = new Vector2(transform.position.x + SPD * Time.deltaTime, transform.position.y); // moving the char
        }
    }

    void ChangeCharacter()
    {
        if (Controls == 0)
        {
            if (Input.GetButtonDown("Girl"))
            {
                anim.Play("Girl");
                c0Script.enabled = true;
                c1Script.enabled = false;
                c2Script.enabled = false;
                curSpeed = dSpeed;
            }
            else if (Input.GetButtonDown("Spirit"))
            {
                anim.Play("Warrior");
                c0Script.enabled = false;
                c1Script.enabled = true;
                c2Script.enabled = false;
                curSpeed = sSpeed;
            }
            else if (Input.GetButtonDown("OldMan"))
            {
                anim.Play("Wizard");
                c0Script.enabled = false;
                c1Script.enabled = false;
                c2Script.enabled = true;
                curSpeed = wSpeed;
            }
        }
        else            //the other movement
        {
            if (Input.GetButtonDown("LeftButton"))
            {
                if (curActivChar != 0)
                {
                    curActivChar -= 1;
                }
                else
                {
                    curActivChar = 2;
                }
               
            }
            if (Input.GetButtonDown("RightButton"))
            {
                if (curActivChar != 2)
                {
                    curActivChar += 1;
                }
                else
                {
                    curActivChar = 0;
                }
            }

            changeChar(curActivChar);
        }
    }
    void changeChar(int nr)
    {
        switch (nr)
        {
            case 0: // the girl
                anim.Play("Girl");
                c0Script.enabled = true;
                c1Script.enabled = false;
                c2Script.enabled = false;
                curSpeed = dSpeed;
                break;
            case 1: // the spirit
                anim.Play("Warrior");
                c0Script.enabled = false;
                c1Script.enabled = true;
                c2Script.enabled = false;
                curSpeed = sSpeed;
                break;
            case 2: // the old man
                anim.Play("Wizard");
                c0Script.enabled = false;
                c1Script.enabled = false;
                c2Script.enabled = true;
                curSpeed = wSpeed;
                break;

            default:
                break;
        }
    }
}
