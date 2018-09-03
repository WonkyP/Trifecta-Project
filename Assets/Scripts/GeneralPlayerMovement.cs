using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    private Rigidbody2D rb;
    public bool right = true;

    // A variable for each character to enable and disable each power
    private ElfMovement c0Script;
    private KnightMovement c1Script;
    private MagicMovement c2Script;

    // A variable for the animations
    Animator anim;

    // A variable to change the color of the Player wen he changes the character
    //private MeshRenderer render;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        // The scripts of the other characters
        c0Script = GetComponent<ElfMovement>();
        c1Script = GetComponent<KnightMovement>();
        c2Script = GetComponent<MagicMovement>();

        //// The component to switch the color for each character
        //render = GetComponent<MeshRenderer>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ChangeCharacter();
        SelectCharacter();
    }

    // Update for physics engine
    void FixedUpdate()
    {
        GeneralMovement(); 
    }

    // General movement of the player
    void GeneralMovement()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime * h, transform.position.y);
        //rb.AddForce(Vector2.right * speed * h);
        //if (h == 0)
        //{
        //    right = true;
        //    rb.velocity = new Vector2(0, rb.velocity.y);
        //}
        //else
        //{
        //    right = false;
        //}

    }

    void ChangeCharacter()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //anim.Play("ChangeCharacter");
            GameManager.instance.CharacterManager();
        }
    }

    // Enable and disable the scripts of each character to select the powers
    void SelectCharacter()
    {
        switch (GameManager.instance.getCurrentCharacter())
        {
            case 0:
                anim.Play("Girl");
                c2Script.enabled = false;
                c0Script.enabled = true;
                break;
            case 1:
                anim.Play("Warrior");
                c0Script.enabled = false;
                c1Script.enabled = true;
                break;
            case 2:
                anim.Play("Wizard");
                c1Script.enabled = false;
                c2Script.enabled = true;
                break;
        }
    }
}
