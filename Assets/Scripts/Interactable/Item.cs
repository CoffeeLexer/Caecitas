using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : Interactive
{
    [SerializeField] 
    private Sprite slotSprite;
    
    public Vector3 heldRotation = Vector3.zero;

    private bool _isHeld;
    private Rigidbody _rigidbody;

    public Sprite SlotSprite => slotSprite;
    public bool IsHeld => _isHeld;

    private void Start()
    {
        _isHeld = false;
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnInteract()
    {
        if(_isHeld) return;
        Inventory.Take(this);
    }

    public void SetHeldState(bool isHeld)
    {
        
        if(isHeld)
        {
            SetMaterial(Global.Objects.holdMaterial);
        }
        else
        {
            var c = GetComponent<MoveToOrigin>();
            if (c)
            {
                Destroy(c);
            }
            ResetMaterial();
        }
        if (_isHeld == isHeld) return;
        _isHeld = isHeld;

        if (_rigidbody)
        {
            _rigidbody.isKinematic = _isHeld;
            _rigidbody.detectCollisions = !_isHeld;
        }
    }

    protected override void OnLook()
    {
        if (!_isHeld)
        {
            base.OnLook();
        }
    }
    protected override void OnLookAway()
    {
        if (!_isHeld)
        {
            base.OnLookAway();
        }
    }
}