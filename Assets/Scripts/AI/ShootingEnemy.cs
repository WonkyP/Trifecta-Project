﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Bullet;
    public float fireRate = 2.0f;
    private float fireTimer;
    public bool Facing_Right = true;

    // Use this for initialization
    void Start()
    {
        fireTimer = fireRate;
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
            //GameObject obj = ObjectPooler.instance.getItemFromPool("Turret_Enemy_Bullets");
            //obj.transform.position = FirePoint.transform.position;
            //obj.transform.rotation = FirePoint.transform.rotation;
            //obj.SetActive(true);
            ObjectPooler.instance.spawnFromPool("Turret_Enemy_Bullets", FirePoint.transform.position, FirePoint.transform.rotation);

            fireTimer = fireRate;
        }

    }

    private void Flip()
    {
        if (!Facing_Right)
            transform.Rotate(0f, 180, 0f);
    }
}
