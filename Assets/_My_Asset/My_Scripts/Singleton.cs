using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T newInstance = FindAnyObjectByType<T>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            RegsisterInstance((T)(MonoBehaviour)this);
        }
        else if (_instance != null)
        {
            Destroy(this);
        }
    }

    private void RegsisterInstance(T newInstance)
    {
        if (newInstance == null) return;
        _instance = newInstance;
    }
}
