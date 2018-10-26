using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayerMovement : MonoBehaviour {
    [HideInInspector]
    public int Controls = 1;

    [Header("Daughter Stats")]
    public float dSpeed;

    [Header("Spirit Stats")]
    public float sSpeed;

    [Header("Wizard Stats")]
    public float wSpeed;

    float curSpeed;

    //private Rigidbody2D rb; // a relic from when we used force to move the char
    [HideInInspector]
    public bool right = true;

    // A variable for each character to enable and disable each power
    private DaughterMovement c0Script;
    private SpiritMovement c1Script;
    private FatherMovement c2Script;

    private GameManager c3Script;

    // A variable for the animations
    Animator anim;
    [HideInInspector]
    public int characterSelected = 2;// this variable will be used for the GameManager Getter "updateHUD" to change the HUD when Control = 0

    // A variable to change the color of the Player wen he changes the character
    //private MeshRenderer render;
    SpriteRenderer sR;


    // FOR THE OTHER CONTROLS
    //int curActivChar;


    // CANVAS
    GameObject AbilityWheel;
    Animator WheelAnimator;


    //Gravity Control
    [Header("Jumping ARK")]
    public float gFourceDown = 4;
    public float gFourceUp = 3;
    // You don't get the gravity of this var
    [HideInInspector]
    public float velY;
    Rigidbody2D rb;

    [Header("Dead Zone for movement")]
    public float movementDeadZone = 0.1f;

    [Header("Char Speed")]
    public float MoveSpeed;
    float SPD;

    [Header("colliding")]
    public LayerMask layers;

    public void ChangeMovements(int move) // change movements
    {
        Controls = move;
        this.gameObject.SendMessage("Start");
    }

    // Use this for initialization
    void Start ()
    {
        characterSelected = PlayerPrefs.GetInt("CharNr", 2);

        // get rb
        rb = GetComponent<Rigidbody2D>();

        // sR
        sR = GetComponent<SpriteRenderer>();

        // THE HUD (AbilityWheel)
        AbilityWheel = GameObject.FindGameObjectWithTag("AbilityWheel");
        if (AbilityWheel != null)
        {
            WheelAnimator = AbilityWheel.GetComponent<Animator>();
        }

        // The scripts of the other characters
        c0Script = GetComponent<DaughterMovement>();
        c1Script = GetComponent<SpiritMovement>();
        c2Script = GetComponent<FatherMovement>();


        anim = GetComponent<Animator>();
    
        curSpeed = dSpeed;

    }

    void Update() // used to get the player input since they don't live in frames
    {
        ChangeCharacter();
    }

    // Update for physics engine
    void FixedUpdate()
    {
        MoveSpeed = Input.GetAxis("Horizontal"); // for animation

        GeneralMovement();
        GravityControl();
    }

    // General movement of the player
    void GeneralMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0) // goes right
            {
                RaycastHit2D rightWall = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y + 1f), Vector2.down, 0.5f);
                Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y + 1f), new Vector2(0, -0.5f), Color.green);
                if (rightWall)
                {
                    if (rightWall.collider.gameObject.layer == 12 || rightWall.collider.gameObject.layer == 13)
                    {
                        print(rightWall.collider.name);
                        return;
                    }

                }
            }
            if (Input.GetAxis("Horizontal") < 0) // goes left
            {
                RaycastHit2D leftWall = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y + 1f), Vector2.down, 0.5f);
                Debug.DrawRay(new Vector2(transform.position.x - 0.5f, transform.position.y + 1f), new Vector2(0, -0.5f), Color.green);
                if (leftWall)
                {
                    if (leftWall.collider.gameObject.layer == 12 || leftWall.collider.gameObject.layer == 13)
                    {
                        print(leftWall.collider.name);
                        return;
                    }

                }
            }




            if (Input.GetAxis("Horizontal") <= movementDeadZone && Input.GetAxis("Horizontal") >= -movementDeadZone)
            {
                return;
            }
            SPD = curSpeed * Input.GetAxis("Horizontal"); // set spd to the curspeed and dir the player is walking
            transform.position = new Vector2(transform.position.x + SPD * Time.deltaTime, transform.position.y); // moving the char

            // LEFT RIGHT
            if (Input.GetAxis("Horizontal") < 0)
            {
                right = false;
                sR.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                right = true;
                sR.flipX = false;
            }
        }
    }

    void ChangeCharacter()
    {
       // the player controls where the player change who they are by pressing X Y B on the controller || A S D on keyboard
            if (Input.GetButtonDown("Girl"))
            {
            //anim.Play("Girl");
            anim.SetInteger("Char", 0);
            c0Script.enabled = true;
            c1Script.enabled = false;
            c2Script.enabled = false;
            characterSelected = 0;
            PlayerPrefs.SetInt("CharNr", characterSelected);

            curSpeed = dSpeed;
            }
            else if (Input.GetButtonDown("Spirit"))
            {
            //anim.Play("Warrior");
            anim.SetInteger("Char", 2);

            c0Script.enabled = false;
            c1Script.enabled = true;
            c2Script.enabled = false;
            characterSelected = 1;
            PlayerPrefs.SetInt("CharNr", characterSelected);

            curSpeed = sSpeed;
            }
            else if (Input.GetButtonDown("OldMan"))
            {
            //anim.Play("Wizard");
            anim.SetInteger("Char", 1);

            c0Script.enabled = false;
            c1Script.enabled = false;
            c2Script.enabled = true;
            characterSelected = 2;
            PlayerPrefs.SetInt("CharNr", characterSelected);

            curSpeed = wSpeed;
            }
        if (WheelAnimator != null)
        {
            WheelAnimator.SetInteger("Character", characterSelected); // change the hud wheel

        }

        //GameManager.instance.updateHUD(characterSelected);
        

        //the Switch Movement where the player changes char with LB and RB on the controller
        if (Input.GetButtonDown("RightButton"))
        {
            if (characterSelected != 2)
            {
            characterSelected += 1;
            }
            else
            {
            characterSelected = 0;
            }

            PlayerPrefs.SetInt("CharNr", characterSelected);


        }
        if (Input.GetButtonDown("LeftButton"))
        {
            if (characterSelected != 0)
            {
            characterSelected -= 1;
            }
            else
            {
            characterSelected = 2;
            }

            PlayerPrefs.SetInt("CharNr", characterSelected);

        }

        changeChar(characterSelected);

    }

    void changeChar(int nr) // just an function made to make it clearer how the switching happens
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

        if (AbilityWheel != null)
        {
            WheelAnimator.SetInteger("Character", nr); // change the hud wheel

        }

        GameManager.instance.updateHUD(nr);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.missionComplete();
    }

    void GravityControl()
    {
        velY = rb.velocity.y;
        if (velY < 0)
        {
            if (velY > -20)
            {
                rb.gravityScale = gFourceDown;

            }
            else
            {
                rb.gravityScale = 0;
            }
        }
        else
        {
            rb.gravityScale = gFourceUp;
        }
    }
}
