using System;
using UnityEngine;

public static class Global<T> where T : class
{
    private static T _instance = null;

    public static T Bind(T obj)
    {
        if (_instance == null)
        {
            _instance = obj;
        }
        else
        {
            Debug.LogError($"Only one {typeof(T)} instance can be created!");
        }
        
        return _instance;
    }
}

public class Global : MonoBehaviour
{
    private static Global _instance;
    
    public Material holdMaterial;
    public Material inspectMaterial;
    
    [SerializeField] public float metronomeRadius = 2.0f;
    [SerializeField] public float metronomePeriod = 1.0f;

    [SerializeField] public float soundSpeed = 2.0f;
    
    [SerializeField] public float throwForce = 25.0f;

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