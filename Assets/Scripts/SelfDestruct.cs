
using System;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private void Start()
    {
        Destroy(transform);
        Destroy(gameObject);
    }

    private void Awake()
    {
        Destroy(transform);
        Destroy(gameObject);
    }
}