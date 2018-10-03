using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{

    private GameObject player_;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_ = collision.gameObject;
            player_.transform.parent = GetComponentInChildren<Transform>().transform;
        }

        //Debug.Log("He entrado aqui");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_.transform.parent = null;
        }
    }
}

