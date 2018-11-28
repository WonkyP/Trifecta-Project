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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GeneralPlayerMovement>().touchedByEnemy(transform.localScale.x / Mathf.Abs(transform.localScale.x), 2);
            collision.gameObject.GetComponent<GeneralPlayerMovement>().Damaged();

            if (collision.gameObject.GetComponent<SpiritNewMovement>().enabled)
            {
                collision.gameObject.GetComponent<SpiritNewMovement>().damaged();
            }
            else if (collision.gameObject.GetComponent<DaughterMovement>().enabled)
            {
                collision.gameObject.GetComponent<DaughterMovement>().damaged();
            }
            else if (collision.gameObject.GetComponent<FatherNewMovement>().enabled)
            {
                collision.gameObject.GetComponent<FatherNewMovement>().damaged();
            }
        }

        objectPooler.killGameObject(gameObject);
        //gameObject.SetActive(false);
    }

}
