using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    readonly Dictionary<int, Pool> Pools = new Dictionary<int, Pool>();

    private Pool GetPool(GameObject prefab)
    {
        int PoolKey = prefab.GetInstanceID();
        if(Pools.ContainsKey(PoolKey))
        {
            return Pools[PoolKey];
        }
        else
        {
            Pool newPool = new Pool(prefab);
            Pools.Add(PoolKey, newPool);
            return newPool;
        }    
    }
        
    public GameObject GetObject(GameObject prefab, Vector3 position)
    {
        Pool ObjectPool = GetPool(prefab);
        return ObjectPool.GetObject(position);
    }

}
