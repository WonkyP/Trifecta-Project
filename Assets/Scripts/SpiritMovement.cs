using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{ 
    RaycastHit2D hit;
    GameObject box;
    //private Rigidbody2D rb; 
    private GeneralPlayerMovement script;


    //Other Controlls
    GeneralPlayerMovement gpm;
    int controls;

    // Use this for initialization
    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();
        script = GetComponent<GeneralPlayerMovement>();

        gpm = GetComponent<GeneralPlayerMovement>();
        controls = gpm.Controls;
	}
	
	// Update is called once per frame
	void Update () {
        if (controls == 0) // The X Y B controller layout
        {
            if (Input.GetButton("AbilityA 01") && NextToBox())
            {
                box = hit.collider.gameObject;
                box.transform.parent = transform;
            }
            else if (Input.GetButtonUp("AbilityA 01"))
            {
                try
                {
                    box.transform.parent = null;
                }
                catch
                {
                    Debug.Log("Box without parent attached");
                }
            }
        }
        else // the LB and RB controller layout
        {
            if (Input.GetButton("AbilityB 01") && NextToBox())
            {
                box = hit.collider.gameObject;
                box.transform.parent = transform;
            }
            else if (Input.GetButtonUp("AbilityB 01"))
            {
                try
                {
                    box.transform.parent = null;
                }
                catch
                {
                    Debug.Log("Box without parent attached");
                }
            }
        }


       

        //if (Input.GetKey(KeyCode.Z) && NextToBox())
        //{
        //    box = hit.collider.gameObject;
        //    box.transform.parent = transform;
        //}
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    try
        //    {
        //        box.transform.parent = null;
        //    }
        //    catch
        //    {
        //        Debug.Log("Box without parent attached");
        //    }
            
        //}


        Debug.DrawRay(transform.position + new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.right * transform.localScale.x, Color.green);
        Debug.DrawRay(transform.position - new Vector3(transform.lossyScale.x / 2 + 0.25f, 0.0f, 0.0f), Vector2.left * transform.localScale.x, Color.red);
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
}