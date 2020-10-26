using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
    List<Poolable> pool = new List<Poolable>();
    Poolable prefab;
    Transform group;

    public ObjectPool(Poolable prefab, Transform group)
    {
        this.prefab = prefab;
        this.group = group;
    }

    public Poolable GetObject()
    {
        Poolable obj;
        int nbItems = pool.Count;
        if(nbItems > 0)
        {
            obj = pool[nbItems - 1];
            obj.IsPooled = false;
            pool.RemoveAt(nbItems - 1);
        }
        else
        {
            obj = Object.Instantiate(prefab);
            obj.transform.parent = group;
        }
        return obj;
    }

    public bool PoolObject(Poolable obj)
    {
        if (obj.poolableID == prefab.poolableID && !obj.IsPooled)
        {
            pool.Add(obj);
            obj.IsPooled = true;
            return true;
        }
        return false;                 
    }

    public void Remove(Poolable obj)
    {
        if (pool.Contains(obj))
            pool.Remove(obj);
    }

}
