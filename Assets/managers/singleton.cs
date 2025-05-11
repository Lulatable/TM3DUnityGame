using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton<V> : MonoBehaviour where V : MonoBehaviour
{
    // static = partagé avec tous + seul
    private static V _instance;

    public static V instance
    {
        get
        {
            _instance = (V)FindObjectOfType(typeof(V));
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<V>();
                obj.name = typeof(V).Name;

            }
            return _instance;
        }

    }
}
