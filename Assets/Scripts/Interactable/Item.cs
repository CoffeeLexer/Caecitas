using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactive
{
    [SerializeField] private Material _onLookMaterial;
    [SerializeField] private Material _onHeldMaterial;
    [SerializeField] private Sprite _slotSprite;
    public Vector3 heldRotation = Vector3.zero;

    private List<Tuple<MeshRenderer, Material>> _childRenderers;

    private bool _isHeld;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _isHeld = false;
        _rigidbody = GetComponent<Rigidbody>();

        _childRenderers = new List<Tuple<MeshRenderer, Material>>();
        extractChildRenderer(gameObject);
    }

    private void extractChildRenderer(GameObject obj)
    {
        foreach (GameObject child in obj.transform)
        {
            extractChildRenderer(child);
        }
        
        var renderer = obj.GetComponent<MeshRenderer>();
        if(!renderer) return;
        
        var defaultMaterial = renderer.material;
        _childRenderers.Add(new Tuple<MeshRenderer, Material>(renderer, defaultMaterial));
    }

    private void SetMaterial(Material material)
    {
        foreach (var child in _childRenderers)
        {
            child.Item1.material = material;
        }
    }

    private void ResetMaterial()
    {
        foreach (var child in _childRenderers)
        {
            child.Item1.material = child.Item2;
        }
    }
    
    protected override void OnLook()
    {
        if(_isHeld) return;
        
        if (_onLookMaterial)
            SetMaterial(_onLookMaterial);
    }

    protected override void OnLookAway()
    {
        if(_isHeld) return;
        ResetMaterial();
    }

    protected override void OnInteract(CameraPointer ptr)
    {
        if(_isHeld) return;
        Global.Toolbar.TakeItem(this);
    }

    public Sprite GetSlotSprite()
    {
        return _slotSprite;
    }

    public void SetHeldState(bool isHeld)
    {
        if (_isHeld == isHeld) return;

        if(_isHeld)
            SetMaterial(_onHeldMaterial);
        else
            ResetMaterial();
        
        _isHeld = isHeld;

        if (_rigidbody)
        {
            _rigidbody.isKinematic = _isHeld;
            _rigidbody.detectCollisions = !_isHeld;
        }
    }
}