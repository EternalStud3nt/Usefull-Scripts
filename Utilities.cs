using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public class listVariable
    {
        public string name;
    }
    public class ChanceSpawnable : listVariable
    {        
        [HideInInspector]public float minChance;  
        [HideInInspector]public float maxChance;
        [Range(0, 100)]
        public float chance;
    }

    /// <summary>
    /// a coroutine that exexutes a function after some seconds have passed, use "StartCoroutine"
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="action"></param>
    /// <returns></returns>
   public static IEnumerator ExecuteAfterSeconds(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }

    /// <summary>
    /// Get an object of type ChanceSpawnable based on the chance that it has among others in the same list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public  static T GetFromListWitthChances<T>(List<T> list) where T: ChanceSpawnable
    {
        // sum all the chances
        float chanceSum = 0;
        foreach (T spawnable in list)
        {
            chanceSum += spawnable.chance;
        } // when this is over chance sum is equal to all of the added chances of all the objects in the list

        // generate a random number inside that chanceSum
        float random = UnityEngine.Random.Range(0, chanceSum);

        for(int i =0; i<list.Count;i++)
        {
            T current = list[i];

            if(i==0)
            {
                current.minChance = 0;
                current.maxChance = current.chance;

                if (current.maxChance >= random)
                {
                    return current;
                }
                    
            }
            else
            {
                current.minChance = list[i - 1].maxChance;
                current.maxChance = current.minChance + current.chance;

                if (current.minChance < random && current.maxChance >= random)
                {

                    return current;
                }
            }          
        }
        return null;
    }
}
