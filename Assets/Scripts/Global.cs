using System;
using Unity.VisualScripting;
using UnityEngine;

public static class Global<T> where T : class
{
    private const bool debug = false;
    
    private static T _instance = null;

    public static T Bind(T obj)
    {
        if (debug)
        {
            if (_instance == null)
            {
                _instance = obj;
            }
            else
            {
                Debug.LogError($"Only one {typeof(T)} instance can be created!");
            }
        }
        else
        {
            MonoBehaviour mono = _instance as MonoBehaviour;
            if (_instance != null && mono != null)
            {
                mono.AddComponent<SelfDestruct>();
            }
            _instance = obj;
        }
        
        return _instance;
    }

    public static void UnBind()
    {
        _instance = null;
    }
}

public class Global : MonoBehaviour
{
    private static Global _instance;
    
    public Material holdMaterial;
    public Material inspectMaterial;
    
    [SerializeField] 
    public float metronomeRadius = 2.0f;
    [SerializeField]
    public float metronomePeriod = 1.0f;

    [SerializeField]
    public float soundSpeed = 2.0f;
    
    [SerializeField]
    public float throwForce = 25.0f;

    private void Awake()
    {
        _instance = Global<Global>.Bind(this);
    }

    public static Global Objects
    {
        get => _instance;
        private set {}
    }
}