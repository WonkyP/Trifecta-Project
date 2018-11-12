using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelSpawner : MonoBehaviour {

    public GameObject BoxSpawner1;
    public GameObject BoxSpawner2;

	// Use this for initialization
	void Start () {
        //ObjectPooler.instance.spawnFromPool("Boxes", BoxSpawner1.transform.position, BoxSpawner1.transform.rotation);
        //ObjectPooler.instance.spawnFromPool("Boxes", BoxSpawner2.transform.position, BoxSpawner2.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
            ObjectPooler.instance.spawnFromPool("Boxes", BoxSpawner1.transform.position, BoxSpawner1.transform.rotation);
    }
}
