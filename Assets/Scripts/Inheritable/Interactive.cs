using System;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    protected virtual void OnLook()
    {
        SetMaterial(Global.Objects.inspectMaterial);
    }

    protected virtual void OnLookAway()
    {
        ResetMaterial();
    }

    protected virtual void OnInteract()
    {
        // Overridable method, to define behavior which
        // will initiate after interaction
    }

    public void Look()
    {
        OnLook();
    }

    public void LookAway()
    {
        OnLookAway();
    }

    public void Interact()
    {
        OnInteract();
    } 

    [SerializeField] protected string _text;
    
    private List<Tuple<Renderer, Material>> _childRenderers;
    
    public virtual string Text
    {
        get
        {
            return _text;
        }
        protected set
        {
            _text = value;
        }
    }

    protected virtual void Awake()
    {
        _childRenderers = new List<Tuple<Renderer, Material>>();
        extractChildRenderer(gameObject);
    }
    
    protected void SetMaterial(Material material)
    {
        foreach (var child in _childRenderers)
        {
            child.Item1.material = material;
        }
    }

    protected void ResetMaterial()
    {
        foreach (var child in _childRenderers)
        {
            child.Item1.material = child.Item2;
        }
    }
    
    private void extractChildRenderer(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            extractChildRenderer(child.gameObject);
        }
        
        var renderer = obj.GetComponent<Renderer>();
        if(!renderer) return;
        
        var defaultMaterial = renderer.material;
        _childRenderers.Add(new Tuple<Renderer, Material>(renderer, defaultMaterial));
    }
}