using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        //THESE ARE THINGS TO STORE IN THE POOL
        public string poolTag;
        public GameObject popupHitPrefab;
        public int size;
        public Queue<GameObject> queue = new Queue<GameObject>(); // create queue of objects
    }

    #region Singleton

    public static ObjectPooler Instance;

    public void Awake()
    {
        Instance = this;
    }

    #endregion
    public bool shouldExpand = true;
    public List<Pool> pools;
    public Dictionary<string, Pool> poolDictionary;
    public Canvas popupHitCanvas;
    // Start is called before the first frame update
    void Start()
    {

        poolDictionary = new Dictionary<string, Pool>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>(); // create queue of objects
            pool.queue = objectQueue;
            poolDictionary.Add(pool.poolTag, pool); //add it into the pool dict หาแท็กแล้วพากลับเข้าคิว
            for (int i = 0; i < pool.size; i++) //make sure we add all the objects we wanna add to the queue
            {
                GameObject goingToCreateObject = CreateObject(pool);
                Debug.Log("Create [" + pool.poolTag + "]");
                goingToCreateObject.SetActive(false);
                //objectQueue.Enqueue(goingToCreateObject);
            }

        }
    }

    public GameObject CreateObject(Pool pool)
    {
        GameObject obj = Instantiate(pool.popupHitPrefab, popupHitCanvas.gameObject.transform);
        PooledObject pooledObject = obj.AddComponent<PooledObject>(); //ADD COMPONENT TO AN INSTANCE INSTEAD NOT THE PREFAB
        pooledObject.label = pool.poolTag;
        return obj;
    }


    public void SpawnFromPool(string poolTag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolTag))
        {
            Debug.LogWarning("Pool with tag" + poolTag + "doesn't exist");
        }


        if (shouldExpand)
        {
            if (poolDictionary[poolTag].queue.Count <= 0)
            {
                // Pool rightPool;
                //IteratePoolsWithTag(iTag, out rightPool);
                //1. Instantiate new object
                //2. Enqueue them 
                GameObject goingToCreateObject = CreateObject(poolDictionary[poolTag]);
                goingToCreateObject.SetActive(true);
                goingToCreateObject.transform.position = position;
                goingToCreateObject.transform.rotation = rotation;
                //poolDictionary[poolTag].queue.Enqueue(goingToCreateObject); //DONT NEED THIS COS IT HAS BEEN ENQUEUE IN ADD COMPONENT POOLEDOBJECT ALREADY
                //THIS WILL ONLY CREATE AND SEND ON REQUEST, IT WILL BE USED AT THAT MOMENT AND WILL ENQUEUE ONCE IT HAS BEEN DESTROYED BY ASTEROID (SETACTIVE=FALSE)

            }
            else
            {
                //WE DONT WANT TO ENQUEUE EACH AN EVERY OBJECT. SO WE WILL DO IT ONCE THE OBJECT HAS BEEN INACTIVE (AFTER IT HAS BEEN DESTROYED(INACTIVE) BY THE ASTEROID)
                GameObject objectToSpawn = poolDictionary[poolTag].queue.Dequeue();
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                //  poolDictionary[tag].Enqueue(objectToSpawn); enqueue when inactive
            }

        }
        else
        {
            if (poolDictionary[poolTag].queue.Count > 0)
            {
                //THIS IS THE CASE WHEN WE DONT NEED TO EXPAND, JUST DEQUEUE AND ENQUEUE
                Debug.Log("not in shouldExpand");
                GameObject objectToSpawn = poolDictionary[poolTag].queue.Dequeue();
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                // poolDictionary[poolTag].queue.Enqueue(objectToSpawn);
            }
        }

        //return objectToSpawn;
    }

    /* public bool IteratePoolsWithTag(string tag, out Pool retPool)
     {
         retPool = new Pool();
         for (int i = 0; i < pools.Count; i++)
         {
             if (pools[i].poolTag == tag)
             {
                 retPool = pools[i];
                 return true;
             }
         }
         return false;
     }*/

}
