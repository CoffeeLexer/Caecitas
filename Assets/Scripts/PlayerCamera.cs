using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera: MonoBehaviour
{
    private bool _active;
    private float _rotation;
    private InputActions _inputActions;

    [SerializeField] private Vector2 verticalRange;

    void Start()
    {
        _rotation = transform.rotation.eulerAngles.x;
        _inputActions = new InputActions();
        _inputActions.Player.Look.performed += ctx =>
        {
            var lookStrength = ctx.ReadValue<Vector2>();
            _rotation = _rotation - lookStrength.y;
            _rotation = Mathf.Clamp(_rotation, verticalRange.x, verticalRange.y);
            transform.localRotation = Quaternion.Euler(_rotation % 360, 0, 0);
        };
        SetActive(true);
    }

    private void SetActive(bool newState)
    {
        _active = newState;
        if (_active)
        {
            _inputActions.Player.Look.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            _inputActions.Player.Look.Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}