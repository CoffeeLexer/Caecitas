using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckOnGround : MonoBehaviour
{
    [SerializeField]
    private bool _isTouching = true;

    private void OnTriggerEnter(Collider _)
    {
        _isTouching = true;
        NoiseGenerator.Spawn(transform.position + Vector3.up * 0.05f, 1.0f);
    }

    private void OnTriggerExit(Collider _)
    {
        _isTouching = false;
    }

    public bool IsTouchingGround()
    {
        return _isTouching;
    }
}
