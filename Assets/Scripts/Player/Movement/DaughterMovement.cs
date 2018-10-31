using System.Collections;
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
    Animator anim;
    PlayerAudioOutput PAO;

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

    [Header("Wall Jump")]
    public bool wallJump = false;
    public float PushFromTheWall = 10;
    public float PushUpFromTheWall = 15;
    public float wallStcik = 1;
    public float wallSlide = -2;
    //public LayerMask wallJumpLayer;
    public bool doubleJumpAfterWall = true;

    //[Header("")]
    public void Start()
    {
        // setting vars
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PAO = GetComponent<PlayerAudioOutput>();

        // setting abilities
        GiveAbbility();
    }

    float curVel;

    public void GiveAbbility()
    {
        if (!wallJump)
        {
            if (PlayerPrefs.GetInt("D01", 0) == 1)
            {
                wallJump = true;
            }
        }
    }

    public void Update()
    {
        if (wallJump)
        {
            // checks if the player is in the air
            if (!isGrounded)
            {
                // raycasts to check for walls

                RaycastHit2D rightcheck = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y + 1),
                    Vector2.right, 0.6f);

                Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y + 1),
                    new Vector2(0.6f, 0), Color.cyan);

                RaycastHit2D leftcheck = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y + 1),
                Vector2.right, -0.6f);

                Debug.DrawRay(new Vector2(transform.position.x - 0.5f, transform.position.y + 1),
                    new Vector2(-0.6f, 0), Color.cyan);

                if (leftcheck)
                {
                    if (leftcheck.collider.gameObject.layer == 13)
                    {
                        // animator bool
                        anim.SetBool("WallSlide", true);

                        if (Input.GetButtonDown("Jump"))
                        {
                            anim.SetTrigger("Jump");
                            //PAO.Jump = true;
                            jumping = true;

                            if (doubleJumpAfterWall)
                            {
                                curAirJumpCount = 1;
                            }

                            rb.velocity = new Vector2(PushFromTheWall, PushUpFromTheWall);
                            
                            
                            return;
                        }
                        else if (rb.velocity.y < -2)// slide
                        {
                            rb.velocity = new Vector2(-wallStcik, wallSlide);
                            // animator bool
                            anim.SetBool("WallSlide", true);
                        }
                    }
                    else
                    {
                        // animator bool
                        anim.SetBool("WallSlide", false);
                    }
                }
                else
                {
                    // animator bool
                    //anim.SetBool("WallSlide", false);
                }
                if (rightcheck)
                {
                    if (rightcheck.collider.gameObject.layer == 13)
                    {

                        anim.SetBool("WallSlide", true);
                        if (Input.GetButtonDown("Jump"))
                        {
                            anim.SetTrigger("Jump");
                            //PAO.Jump = true;
                            jumping = true;


                            if (doubleJumpAfterWall)
                            {
                                curAirJumpCount = 1;
                            }

                            rb.velocity = new Vector2(-PushFromTheWall, PushUpFromTheWall);

                            return;
                        }
                        else if (rb.velocity.y < -2)// slide
                        {
                            rb.velocity = new Vector2(wallStcik, wallSlide);
                            anim.SetBool("WallSlide", true);
                        }
                    }
                    else
                    {
                        // animator bool
                        anim.SetBool("WallSlide", false);
                    }// wall slide animator
                }// check tyhe wall on the right side
                else
                {
                    // animator bool
                    //anim.SetBool("WallSlide", false);
                    //anim.SetBool("Jump", false);
                    //PAO.Jump = false;

                }

                if (!rightcheck && !leftcheck)
                {
                    anim.SetBool("WallSlide", false);
                }
            }// check if player is grounded
            else
            {
                //anim.SetBool("WallSlide", false);
            }

        }// Check if wall jumping is Activ

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



    void wallJumping()
    {


        // raycasts to check for walls
        RaycastHit2D rightcheck = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1),
            Vector2.right, 0.6f, JumpableLayers);

        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 1),
            new Vector2(0.6f, 0), Color.cyan);




    }

    public void Jump()
    {
        // Jumping
        if (Input.GetButtonUp("Jump") && jumping == true)// && curAirTime > 0) // jump over
        {
            curAirTime = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 4);

            jumping = false;
            PAO.isJumping = false;
            PAO.isDoubleJump = false;

            //anim.SetBool("Jump", false);
            //anim.SetBool("DoubleJump", false);
        }
        else if (Input.GetButtonDown("Jump") && curCoyoteTime > 0) // take Off
        {
            jumping = true;
            PAO.isJumping = true;
            curCoyoteTime = 0;

            curVel = jumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = airTime; // set how long the button press will be for

            anim.SetTrigger("Jump");
            return;
        }
        else if (Input.GetButton("Jump") && curAirTime > 0) // In The Air
        {
            curAirTime -= Time.deltaTime;

            curVel = curVel - Time.deltaTime * 20;

            rb.velocity = new Vector2(rb.velocity.x, curVel);
            //anim.SetBool("Jump", false);
            //anim.SetBool("DoubleJump", false);


            return;
        }
        //////////////////////////////////////////////////////// X2!!!!
        if (Input.GetButtonDown("Jump") && curAirJumpCount > 0) // checks if the player tries to jump in the air
        {
            curAirJumpCount -= 1;

            jumping = true;
            PAO.isDoubleJump = true;

            curVel = DoubleJumpSpeed; // set the vel

            rb.velocity = new Vector2(rb.velocity.x, curVel); // add the starting force

            curAirTime = DoubleJumpAirTime; // set how long the button press will be for

            anim.SetTrigger("DoubleJump");


            
        }

        // turn jump audio off
        if (PAO.isJumping == true)
        {
            PAO.isJumping = false;
        }
        if (PAO.isDoubleJump == true)
        {
            PAO.isDoubleJump = false;
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
            PAO.isGrounded = true;
            anim.SetBool("isGrounded", true);
            anim.SetBool("WallSlide", false);

        }
        else if (isGrounded)
        {
            isGrounded = false;
            PAO.isGrounded = false;
            anim.SetBool("isGrounded", false);

        }
    }

    private void OnEnable()
    {
        curCoyoteTime = 0;

    }

}