using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayerMovement : MonoBehaviour {
    [Header("Daughter Stats")]
    public float dSpeed;

    [Header("Spirit Stats")]
    public float sSpeed;

    [Header("Wizard Stats")]
    public float wSpeed;

    float curSpeed;

    private Rigidbody2D rb;
    public bool right = true;

    // A variable for each character to enable and disable each power
    private DaughterMovement c0Script;
    private SpiritMovement c1Script;
    private FatherMovement c2Script;

    // A variable for the animations
    Animator anim;

    // A variable to change the color of the Player wen he changes the character
    //private MeshRenderer render;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - curSpeed * Time.deltaTime, transform.position.y);
            rb.AddForce(Vector2.left * curSpeed);
            right = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + curSpeed * Time.deltaTime, transform.position.y);
            rb.AddForce(Vector2.right * curSpeed);
            right = true;
        }
    }

    void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("Girl");
            c0Script.enabled = true;
            c1Script.enabled = false;
            c2Script.enabled = false;
            curSpeed = dSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play("Warrior");
            c0Script.enabled = false;
            c1Script.enabled = true;
            c2Script.enabled = false;
            curSpeed = sSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("Wizard");
            c0Script.enabled = false;
            c1Script.enabled = false;
            c2Script.enabled = true;
            curSpeed = wSpeed;
        }

        //if (Input.GetButtonDown("Fire2"))
        //{
        //    //anim.Play("ChangeCharacter");
        //    GameManager.instance.CharacterManager();
        //}
    }
}
