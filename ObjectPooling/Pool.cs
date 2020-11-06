using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public string name;
    public Transform poolObjectInHierarchy { get; private set; }
    public List<GameObject> inactiveItems;
    public List<GameObject> activeItems;

    public Pool(string name)
    {
        this.name = name;
        poolObjectInHierarchy = new GameObject(name).transform;
        inactiveItems = new List<GameObject>();
        activeItems = new List<GameObject>();
    }

    public void AddToPool(GameObject gameObj) // add to pool and don't change activeness
    {
        if(gameObj.GetComponent<Poolable>()==null)
        {
            gameObj.AddComponent<Poolable>();
            gameObj.GetComponent<Poolable>().SetPool(this);
        }
    }

    public GameObject GetObject()
    {
        if (inactiveItems.Count > 0)
        {
            GameObject obj = inactiveItems[0];
            obj.SetActive(true);
            return obj;
        }
        else
            return null;
    }

}
