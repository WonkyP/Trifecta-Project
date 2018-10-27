using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    // A class to create pools of different objects
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    // A list to store all of our pools
    public List<Pool> pools;

    // New dictionary set to be able to find a specific pool
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Use this for initialization
    void Start()
    {
        // We create a new dictionary
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            // We create a queue for each pool of objects
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // We add the objects to the pools
            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefab);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            // We add the pool to the dictionary
            poolDictionary.Add(pool.tag, objectPool);
        }

    }
}
