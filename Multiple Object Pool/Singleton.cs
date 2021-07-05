using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    protected static T instance;
    protected  void Awake()
    {
        instance = GetComponent<T>();
    }

    public static T GetInstance()
    {
        if(instance!=null)
        {
            return instance;
        }
        else
        {
            GameObject newObject = new GameObject(typeof(T).Name);
            newObject.AddComponent<T>();
            return newObject.GetComponent<T>();
        }    
    }
}
