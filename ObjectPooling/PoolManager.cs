using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    readonly Dictionary<int, Pool>  Pools = new Dictionary<int, Pool>();

    public  GameObject GetObject(GameObject prefab)
    {
        Pool ObjectPool = GetAPool(prefab);
        

        GameObject newObject = ObjectPool.GetObject();      // get the object from the pool that existed / we created 

        if (newObject != null)  // if that object isn't null, and is deactivated (look Pool.cs), return it
        {
            return newObject;
        }
        else  // else, create a new one, add it to the pool items and then return it
        {
            
            newObject = Instantiate(prefab);
            ObjectPool.AddToPool(newObject);
            return newObject;
        }
    }

    private Pool GetAPool(GameObject prefab)
    {
        int poolKey = prefab.GetInstanceID();
        Pool ObjectPool;

        if (!Pools.ContainsKey(poolKey)) // if pool doesn't exist, create one
        {
            ObjectPool = new Pool(prefab.name + " pool");
            Pools.Add(poolKey, ObjectPool);
        }
        else // else get the one that exists
        {
            ObjectPool = Pools[poolKey];
        }

        return ObjectPool;
    }
}
