using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    [HideInInspector]
    public int poolableID;
    public bool IsPooled
    {
        get
        {
            return isPooled;
        }
        set
        {
            isPooled = value;
            gameObject.SetActive(!value);
        }
    }

    bool isPooled;

    private void OnDestroy()
    {
        ObjectPoolsManager.GetInstance().Remove(this);
    }


}
