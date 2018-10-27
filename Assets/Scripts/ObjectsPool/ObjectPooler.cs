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

    // We make the pool a singleton to get access in an easy way
    #region Singleton

    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


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

    // Method to spawn prefabs
    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        // To prevent unexpected errors
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("GameObject with tag '" + tag + "' doesn't exist.");
            return null;
        }

        // We search the pool and select the first element
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        
        // We give life to the gameObject
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        // We add the element selected to the back to reuse it later
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
