using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noisy : MonoBehaviour
{
    [SerializeField] private float _activationSpeed = 1;
    [SerializeField] private float _recordedSpeed;
    [SerializeField] private float _soundRadius = 1;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _recordedSpeed = _rb.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7) return;

        if (_recordedSpeed >= _activationSpeed)
        {
            NoiseGenerator.Spawn(transform.position, _soundRadius);
        }
    }
}
