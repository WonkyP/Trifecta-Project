using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    // A class to create pools of different objects
    [System.Serializable]
    public class objectPoolItem
    {
        public string tag;
        public GameObject objectToPool;
        public int amountToPool;
    }


    // A list to store all of our different types of items
    public List<objectPoolItem> itemsToPool;

    // New dictionary set to be able to find a specific pool
    // public Dictionary<string, List<GameObject>> poolDictionary;
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

        foreach (objectPoolItem item in itemsToPool)
        {
            // We create a queue for each pool of objects
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // We add the objects to the pools
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            // We add the pool to the dictionary
            poolDictionary.Add(item.tag, objectPool);
        }

    }

    // Method to get an item from one of the pools
    public GameObject getItemFromPool(string tag)
    {
        // To prevent unexpected errors
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("GameObject with tag '" + tag + "' doesn't exist.");
            return null;
        }

        //for (int i = 0; i < poolDictionary[tag].Capacity; i++)
        //{
        //    if (!poolDictionary[tag][i].activeInHierarchy)
        //    {
        //        return poolDictionary[tag][i];
        //    }
        //}

        // We search the pool and select the first element
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        // We give life to the gameObject
        //objectToSpawn.SetActive(true);
        //objectToSpawn.transform.position = position;
        //objectToSpawn.transform.rotation = rotation;

        // We add the element selected to the back to reuse it later
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

        //return null;
    }

    // Method to spawn a gameObject from one of the pools
    public void spawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        GameObject obj = getItemFromPool(tag);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
    }

    public void killGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }

}
