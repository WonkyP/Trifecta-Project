using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherMovement : MonoBehaviour
{


    [Header("Jump Stats")]
    public float jumpSpeed = 12;
    public int airJumpCount = 1;
    int curAirJumpCount;


    [Header("Jump from the ground")]
    public float airTime;
    float curAirTime; // this var will change over time

    [Header("Jump without ground")]
    public float DoubleJumpAirTime;


    // Getting varables
    Rigidbody2D rb;
    Animator anim;

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

    // magic
    public bool activatePlatform;


    public GameObject magicBulletKey;
    private BulletKey bulletScript;

    public float bulletVelX;
    public float bulletVelY;

    public bool right = true;


    public bool OnMovablePlatform = false;

    public GameObject rspawner;
    public GameObject lspawner;
    public GameObject downSpawner;


    //[Header("")]
    public void Start()
    {

        // setting vars
        rb   = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    float curVel;


    public void Update()
    {
        GroundCheck();
        MagicPower();




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
        }



        Jump();

        if (Input.GetKeyDown(KeyCode.U))
        {
            //magicBulletKey.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1);

            //bulletScript = magicBulletKey.GetComponent<BulletKey>();

            if (!OnMovablePlatform)
            {

                //float bulletVelX_ = 5.0f;
                if (!right)//will shoot to the left.
                {
                    ObjectPooler.instance.spawnFromPool("BulletKey", lspawner.transform.position, lspawner.transform.rotation);
                }
                //    bulletVelX_ = -bulletVelX;
                else //will shoot to the right.
                {
                    ObjectPooler.instance.spawnFromPool("BulletKey", rspawner.transform.position, rspawner.transform.rotation);
                   
                } /*bulletVelX_ = bulletVelX;*/

                    //bulletScript.SetVelY(0);
                    //bulletScript.SetVelX(bulletVelX_);

                    
                //ObjectPooler.instance.spawnFromPool("BulletKey", lspawner.transform.position, lspawner.transform.rotation);
            }
            else
            { 
                ObjectPooler.instance.spawnFromPool("BulletKey", downSpawner.transform.position, downSpawner.transform.rotation);
            }

            //Instantiate(magicBulletKey);
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

            anim.SetBool("Jump", false);
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

            anim.SetBool("Jump", true);
            return;
        }
        else if (Input.GetButton("Jump") && curAirTime > 0) // In The Air
        {
            curAirTime -= Time.deltaTime;

            curVel = curVel - Time.deltaTime * 20;

            rb.velocity = new Vector2(rb.velocity.x, curVel);

            anim.SetBool("Jump", false);
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


    /// MAGIC POWERS

    void MagicPower()
    {

        if (Input.GetButtonDown("AbilityB 01"))
        {
            if (!activatePlatform)
                activatePlatform = true;
            else
                activatePlatform = false;
        }


    }

    private void OnEnable()
    {
        curCoyoteTime = 0;

    }


    public void changeShotDirecctio(int dir)
    {
        if (dir > 0)
            right = true;
        else right = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovablePlatform")
            OnMovablePlatform = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovablePlatform")
            OnMovablePlatform = false;
    }


}
