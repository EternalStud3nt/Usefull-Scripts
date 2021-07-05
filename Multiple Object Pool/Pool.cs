using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pool
{
    readonly GameObject  prefab;
    readonly List<GameObject> items;
    readonly GameObject poolInHierarchy;
    public Pool(GameObject prefab)
    {
        this.prefab = prefab;
        items = new List<GameObject>();
        poolInHierarchy = new GameObject(prefab.name + " POOL");
        poolInHierarchy.transform.parent = PoolManager.GetInstance().gameObject.transform;
        CreateObjects();
    }

    private void CreateObjects()
    {
        for(int i=0; i<5; i++)
        {
            GameObject newItem = Object.Instantiate(prefab);
            newItem.transform.parent = poolInHierarchy.transform;
            newItem.SetActive(false);
            items.Add(newItem);
        }
    }

    public GameObject GetObject(Vector3 position)
    {
        for(int i=0; i<items.Count; i++)
        {
            GameObject current = items[i];

            if(!current.activeInHierarchy)
            {
                current.transform.position = position;
                current.SetActive(true);            
                return current;
            }
        }
 
        return CreateNewObject(position);
    }

    private GameObject CreateNewObject(Vector3 position)
    {
        GameObject newObj = Object.Instantiate(prefab);
        newObj.transform.position = position;
        items.Add(newObj);
        newObj.SetActive(true);
        newObj.transform.parent = poolInHierarchy.transform;
        return newObj;
    }
}
