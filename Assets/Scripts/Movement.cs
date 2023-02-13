using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private InputActions _inputActions;
    private Rigidbody _rigidbody;
    private Vector3 _movementDirection;
    
    [SerializeField, Min(0)] private float strafeSpeed;
    [SerializeField, Min(0)] private float speed;
    [SerializeField, Min(0)] private float jumpForce;
    

    public void Awake()
    {
        _inputActions = new InputActions();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        _inputActions.Player.Forward.performed += ctx =>
        {
            Debug.Log(ctx.action.IsPressed());
        };
    }
    
    public void OnEnable()
    {
        _inputActions.Enable();
    }

    public void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce);
    }
    
    public void FixedUpdate()
    {

    }
}
