using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKey : MonoBehaviour {

    public float velX_ = 10f;
    public float velY_ = 0f;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(velX_, velY_);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            ObjectPooler.instance.killGameObject(gameObject);
            //Destroy(this.gameObject);
        }
    }

    public void SetVelX(float velX)
    {
        velX_ = velX;
    }

    public void SetVelY(float velY) {
        velY_ = velY;
    }
}
