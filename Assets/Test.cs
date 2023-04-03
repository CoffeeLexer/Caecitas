using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Interactive
{
    private Renderer _renderer;
    private Material _material;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    protected override void OnLook()
    {
    }

    protected override void OnLookAway()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnInteract()
    {
        throw new System.NotImplementedException();
    }
}
