using System;
using System.Collections.Generic;
using UnityEngine;

public class Pooling
{
    public static GameObject GetObject(GameObject prefab)
    {
        return PoolManager.GetInstance().GetObject(prefab);
    }
}
