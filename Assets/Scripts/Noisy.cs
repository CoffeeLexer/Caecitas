using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noisy : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _clip;

    [SerializeField] private float _activationSpeed = 10;
    [SerializeField] private float _maxSound;
    [SerializeField] private float _recordedSpeed;

    [SerializeField] private GameObject obj;
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
            Instantiate(obj, transform.position, Quaternion.identity);
        }
    }
}
