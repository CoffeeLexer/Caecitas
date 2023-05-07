using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    private float Distance
    {
        get => _distance;
        set
        {
            _distance = value;
            transform.localScale = Vector3.one * _distance;
        }

    }

    private static readonly int ColorID = Shader.PropertyToID("_Color");
    
    private float _distance;
    private Material _material;
    private Color _color;

    [SerializeField, Min(0)]
    private float soundSpeed = 300;
    [SerializeField, Min(0)]
    private float maxDistance;

    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _color = _material.GetColor(ColorID);
        
        Distance = 0;
        StartCoroutine(Progress());
    }

    IEnumerator Progress()
    {
        for(Distance = 0; Distance < maxDistance; Distance += soundSpeed * Time.deltaTime)
        {
            _color.a = 1.0f - Distance / maxDistance;
            _material.SetColor(ColorID, _color);
            yield return null;
        }
        Distance = maxDistance;
        _color.a = 0.0f;
        _material.SetColor(ColorID, _color);
        Destroy(gameObject);
    }
}
