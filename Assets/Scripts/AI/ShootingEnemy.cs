using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    ObjectPooler objectPooler;

    public Transform FirePoint;
    public float fireRate = 2.0f;
    private float fireTimer;
    public bool Facing_Right;

    // Use this for initialization
    void Start()
    {
        objectPooler = ObjectPooler.instance;
        fireTimer = fireRate;

        if (!Facing_Right)
            Flip();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    // Script with the shoot logic
    void Shoot()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            objectPooler.spawnFromPool("Turret_Enemy_Bullets", FirePoint.transform.position, FirePoint.transform.rotation);
            fireTimer = fireRate;
        }

    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
            Destroy(gameObject);
    }
}
