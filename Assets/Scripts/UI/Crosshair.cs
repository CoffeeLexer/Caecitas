using System;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private bool _active;
    private float _changeTime;
    private float _changeSpeed;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _duration;
    private void Start()
    {
        SetActive(false);
    }

    public void FixedUpdate()
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

    public void SetActive(bool active)
    {
        if (_active != active)
        {
            _changeSpeed = _speed;
            _changeTime = Time.time;
        }

        _active = active;

    }
}
