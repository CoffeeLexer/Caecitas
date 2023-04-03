using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactive
{
    private Renderer _renderer;
    private Material _material;
    private void Start()
    {
    }

    protected override void OnLook()
    {
        _material.color = Color.blue;
    }

    protected override void OnLookAway()
    {
        _material.color = Color.red;
    }

    protected override void OnInteract()
    {
    }
}
