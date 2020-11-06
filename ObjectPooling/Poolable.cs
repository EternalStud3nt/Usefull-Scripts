using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    private void OnEnable()
    {
        if(MotherPool!=null)
        {
            
            MotherPool.activeItems.Add(gameObject);
            MotherPool.inactiveItems.Remove(gameObject);
            
        }
        
    }
    public Pool MotherPool { get; set; }
    public void SetPool(Pool pool)
    {
        MotherPool = pool;
        transform.parent = MotherPool.poolObjectInHierarchy;
        if (gameObject.activeInHierarchy)
        {
            MotherPool.activeItems.Add(gameObject);
            MotherPool.inactiveItems.Remove(gameObject);
        }
        else
        {
            MotherPool.activeItems.Remove(gameObject);
            MotherPool.inactiveItems.Add(gameObject);
        }
    }

    private void OnDisable()
    {
        MotherPool.activeItems.Remove(gameObject);
        MotherPool.inactiveItems.Add(gameObject);
    }
}
