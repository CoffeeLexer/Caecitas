using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    private static NoiseGenerator _instance;
    
    [SerializeField] private GameObject _noise;
    
    private void Awake()
    {
        _instance = Global<NoiseGenerator>.Bind(this);
    }

    public static void Spawn(Vector3 position, float radius) => _instance.spawn(position, radius);
    private void spawn(Vector3 position, float radius)
    {
        if (!_noise)
        {
            Debug.LogError("Noise prefab not initialized");
        }
        else
        {
            GameObject newSound = Instantiate(_noise, position, Quaternion.identity);
            newSound.GetComponent<SoundBehavior>().Travel(radius);
        }
    }
}
