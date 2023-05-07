using System;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private static Crosshair _instance;
    
    private bool _active;
    private float _changeTime;
    private float _changeSpeed;
    
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _duration;
    
    private void Awake()
    {
        _instance = Global<Crosshair>.Bind(this);
        SetActive(false);
    }

    private void FixedUpdate()
    {
        float t = (Time.time - _changeTime) / _duration;
        
        if (_active)
        {
            _speed = Mathf.SmoothStep(_changeSpeed, _maxSpeed, t);
        }
        else
        {
            _speed = Mathf.SmoothStep(_changeSpeed, 0, t);
        }
        transform.Rotate(new Vector3(0, 0, _speed));
    }

    public static void SetActive(bool active) => _instance.setActive(active);
    
    private void setActive(bool active)
    {
        if (_active != active)
        {
            _changeSpeed = _speed;
            _changeTime = Time.time;
        }

        _active = active;
    }
}
