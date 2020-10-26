using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public bool isPersistent;
    public static T instance;
    public static T GetInstance()
    {
        if(!instance)
        {
            var obj = new GameObject(typeof(T).Name, typeof(T)).GetComponent<T>();
            instance = obj;
            if (obj.isPersistent)
                DontDestroyOnLoad(obj);

        }
        return instance;
    }
    private void Awake()
    {
        if(!instance)
        {
            instance = gameObject.GetComponent<T>();
            if (isPersistent)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != gameObject.GetComponent<T>())
            {
                Destroy(gameObject);
            }
        }
    }
}
