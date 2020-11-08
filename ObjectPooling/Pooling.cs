using System;
using System.Collections.Generic;
using UnityEngine;

public class Pooling
{
    public static GameObject GetObject(GameObject prefab, Vector3 position)
    {
        return PoolManager.GetInstance().GetObject(prefab, position);
    }
}
