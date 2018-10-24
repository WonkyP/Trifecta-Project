using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Bullet;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // Script with the shoot logic
    void Shoot()
    {
        Instantiate(Bullet, FirePoint.transform);
    }
}
