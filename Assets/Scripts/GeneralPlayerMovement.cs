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


        anim = GetComponent<Animator>();


        curSpeed = dSpeed;
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
        transform.position = new Vector2(transform.position.x + curSpeed * Time.deltaTime * h, transform.position.y);
        rb.AddForce(Vector2.right * curSpeed * h);

        if (h > 0)
        {
            right = true;
        }
        else if(h < 0)
        {
            right = false;
        }

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
                curSpeed = dSpeed;
                break;
            case 1:
                anim.Play("Warrior");
                c0Script.enabled = false;
                c1Script.enabled = true;
                curSpeed = sSpeed;
                break;
            case 2:
                anim.Play("Wizard");
                c1Script.enabled = false;
                c2Script.enabled = true;
                curSpeed = wSpeed;
                break;
        }
    }
}
