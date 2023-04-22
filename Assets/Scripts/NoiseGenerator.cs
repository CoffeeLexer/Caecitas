using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _noise;
    
    private void Awake()
    {
        Global.NoiseGenerator = this;
    }

    public void Spawn(Vector3 position, float radius)
    {
        GameObject newSound = Instantiate(_noise, position, Quaternion.identity);
        newSound.GetComponent<SoundBehavior>().Travel(radius);
    }
}
