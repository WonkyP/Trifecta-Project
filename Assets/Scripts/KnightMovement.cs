using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{

    RaycastHit2D hit;
    GameObject box;
    private Rigidbody2D rb;
    private GeneralPlayerMovement script;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<GeneralPlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire3") && NextToBox())
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = rb;
            box.GetComponent<Rigidbody2D>().mass = 0.0001f;
        }
        else if (Input.GetButtonUp("Fire2") && NextToBox())
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<Rigidbody2D>().mass = 1;
        }

        Debug.DrawRay(transform.position + new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.right * transform.localScale.x, Color.green);
        Debug.DrawRay(transform.position - new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.left * transform.localScale.x, Color.red);
    }

    bool NextToBox()
    {
        //try
        //{
            if (script.right)
                hit = Physics2D.Raycast(transform.position + new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.right * transform.localScale.x, 1.0f);
            else
                hit = Physics2D.Raycast(transform.position - new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.left * transform.localScale.x, 1.0f);

            Debug.Log(hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Box")
                return true;
            else
                return false;
        //}
        //catch
        //{
            //Debug.Log("Variable hit is null");
        //}


        return false;
    }
}