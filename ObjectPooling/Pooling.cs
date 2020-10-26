using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling 
{
    public static GameObject GetObject(GameObject obj, System.Func<GameObject, GameObject> fallbackMethod)
    {
        var poolable = obj.GetComponent<Poolable>();
        if (ReferenceEquals(poolable, null))
            return fallbackMethod(obj);
        return ObjectPoolsManager.GetInstance().GetObject(poolable).gameObject;
    }

    public static bool TryPool(GameObject obj, System.Func<GameObject, bool> fallbackMethod)
    {
        var poolable = obj.GetComponent<Poolable>();
        if (ReferenceEquals(poolable, null))
            return fallbackMethod(obj);
        return ObjectPoolsManager.GetInstance().PoolObject(poolable);
    }

    public static bool TryPool(GameObject obj)
    {
        return TryPool(obj, DefaultPoolFallback);
    }

    public static GameObject GetObject(GameObject obj)
    {
        return GetObject(obj, DefaultGetObjectFallback);
    }

    static bool DefaultPoolFallback(GameObject obj)
    {
        try
        {
            Object.Destroy(obj);
            return true;
        }
        catch
        {
            return false;
        }
    }

    static GameObject DefaultGetObjectFallback(GameObject obj)
    {
        return Object.Instantiate(obj);
    }
}
