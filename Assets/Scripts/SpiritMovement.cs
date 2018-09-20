using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{ 
    RaycastHit2D hit;
    GameObject box;
    private GeneralPlayerMovement script;


    //Other Controlls
    GeneralPlayerMovement gpm;
    int controls;

    // Use this for initialization
    void Start ()
    {
        script = GetComponent<GeneralPlayerMovement>();

        gpm = GetComponent<GeneralPlayerMovement>();
        controls = gpm.Controls;
	}
	
	// Update is called once per frame
	void Update () {
        // How to Debug raycast, in case we need it
        //Debug.DrawRay(transform.position + new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.right * transform.localScale.x, Color.green);
        //Debug.DrawRay(transform.position - new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.left * transform.localScale.x, Color.red);
    }

    bool NextToBox()
    {
        try
        {
            if (script.right)
                hit = Physics2D.Raycast(transform.position + new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.right * transform.localScale.x, 1.0f);
            else
                hit = Physics2D.Raycast(transform.position - new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.left * transform.localScale.x, 1.0f);

            //Debug.Log(hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Box")
                return true;
            else
                return false;
        }
        catch
        {
            Debug.Log("Variable hit is null");
        }


        return false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (controls == 0)
        {
            if (enabled && Input.GetButton("AbilityA 01") && collision.gameObject.tag == "Box")
            {
                box = collision.gameObject;
                box.transform.parent = transform;
            }

            if (enabled && Input.GetButtonUp("AbilityA 01"))
            {
                box.transform.parent = null;
                Debug.Log("EEEEEEEEEEEEEEEEEEE!");
            }
        }
        else
        {
            if (enabled && Input.GetButton("AbilityA 01") && collision.gameObject.tag == "Box")
            {
                box = collision.gameObject;
                box.transform.parent = transform;
            }

            if (enabled && Input.GetButtonUp("AbilityA 01"))
            {
                box.transform.parent = null;
            }
        }
        
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
            box.transform.parent = null;
    }


    private void OnDisable()
    {
        if (box.transform.parent != null)
            box.transform.parent = null;
    }
}