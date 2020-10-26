using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectPoolsManager : Singleton<ObjectPoolsManager>
{
    Dictionary<int, ObjectPool> pools = new Dictionary<int, ObjectPool>();
    public Poolable GetObject(Poolable prefab)
    {
        if (prefab.poolableID == 0)
            prefab.poolableID = prefab.GetInstanceID();
        int instanceID = prefab.poolableID;
        if (pools.ContainsKey(instanceID))
            return pools[instanceID].GetObject();
        Transform group = new GameObject(prefab.name + instanceID).transform;
        group.SetParent(transform);
        ObjectPool pool = new ObjectPool(prefab, group);
        pools.Add(instanceID, pool);
        Poolable obj = pool.GetObject();

        return obj;
    }

    public bool PoolObject(Poolable obj)
    {
        if(pools.ContainsKey(obj.poolableID))
        {
            return pools[obj.poolableID].PoolObject(obj);
        }
        return false;
    }

    public void Remove(Poolable obj)
    {
        if (pools.ContainsKey(obj.poolableID))
            pools[obj.poolableID].Remove(obj);     
    }
        
}
