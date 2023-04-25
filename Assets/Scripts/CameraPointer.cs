using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CameraPointer : MonoBehaviour
{
    private Interactive _focusedObject;
    private InputActions _inputActions;
    
    private Vector3 _lookingAt;
    
    [SerializeField] private float _reachRange;
    [SerializeField] private float _putRange;

    private void Awake()
    {
        _inputActions = new InputActions();
        _focusedObject = null;
        _inputActions.Player.Interact.Enable();
        _inputActions.Player.Interact.performed += ctx => Interact();
    }

    private void FixedUpdate()
    {
        Interactive newFocus = null;
        
        var direction = transform.TransformDirection(Vector3.forward);
        direction.Normalize();
        float distance = _putRange;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit))
        {
            distance = Mathf.Min(hit.distance, distance);

            if (hit.transform.TryGetComponent<Interactive>(out var interactive))
            {
                if (hit.distance < _reachRange)
                {
                    newFocus = interactive;
                }
            }
        }
        Player.SetPutPosition(transform.position + direction * distance);
        Player.SetThrowDirection(direction);
        SetFocus(newFocus);
    }

    private void SetFocus(Interactive interactive)
    {
        if (_focusedObject == interactive) 
            return;

        if (_focusedObject)
        {
            _focusedObject.LookAway();
        }

        Identifier.SetText(String.Empty);
        Crosshair.SetActive(_focusedObject);
        _focusedObject = interactive;

        if (_focusedObject)
        {
            _focusedObject.Look();
            Identifier.SetText(_focusedObject.Text);
        }
    }

    private void Interact()
    {
        if (_focusedObject)
        {
            _focusedObject.Interact();
        }
    }
    
    public void OnEnable()
    {
        _inputActions.Enable();
    }

    public void OnDisable()
    {
        _inputActions.Disable();
    }
}