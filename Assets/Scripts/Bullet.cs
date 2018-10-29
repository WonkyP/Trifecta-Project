using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
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
        objectPooler.killGameObject(gameObject);
        //gameObject.SetActive(false);
    }

}
