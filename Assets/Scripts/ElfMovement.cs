using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfMovement : MonoBehaviour
{
    // Carl was here!
    public float JumpForce = 5;
    private Rigidbody2D rb;
    private bool jumping = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && isGrounded())
            jumping = true;
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if (jumping)
        {
            //rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            // modifying the velocity of the rigidbody solves a bug that appears using addForce
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.y);
            jumping = false;
        }
    }

    bool isGrounded()
    {
        if (Physics2D.Raycast(transform.position - new Vector3(0.0f, transform.lossyScale.y / 2 + 0.02f, 0.0f), Vector2.down, 0.001f))
            return true;
        else
            return false;
    }

}