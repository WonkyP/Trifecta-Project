using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    ObjectPooler objectPooler;

    GameObject respawnGo;
    Vector2 respawnPos;

	// Use this for initialization
	void Start () {
        objectPooler = ObjectPooler.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        respawnGo = collision.gameObject;
        objectPooler.killGameObject(respawnGo);

        if (collision.gameObject.tag == "Box")
        {
            respawnPos = collision.gameObject.GetComponent<Box>().getStartPosition();
            objectPooler.spawnFromPool("Boxes", respawnPos, respawnGo.transform.rotation);
        }
       
    }
}
