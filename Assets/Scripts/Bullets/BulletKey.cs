using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKey : MonoBehaviour, IPooledObject
{
    ObjectPooler objectPooler;
    public float speed = 5f;
    public Rigidbody2D rb;

    // Use this for initialization
    public void OnObjectSpawn()
    {
        objectPooler = ObjectPooler.instance;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag != "Player")
        objectPooler.killGameObject(gameObject);
    }

    //   public float velX_ = 10f;
    //   public float velY_ = 0f;
    //   Rigidbody2D rb;
    //// Use this for initialization
    //void Start () {

    //       rb = GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update () {
    //       rb.velocity = new Vector2(velX_, velY_);
    //}

    //   private void OnTriggerEnter2D(Collider2D collision)
    //   {
    //       if (collision.gameObject.tag != "Player")
    //       {
    //           ObjectPooler.instance.killGameObject(gameObject);
    //           //Destroy(this.gameObject);
    //       }
    //   }

    //   public void SetVelX(float velX)
    //   {
    //       velX_ = velX;
    //   }

    //   public void SetVelY(float velY) {
    //       velY_ = velY;
    //   }
}
