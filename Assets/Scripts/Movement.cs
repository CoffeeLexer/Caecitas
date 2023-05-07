using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    enum Direction
    {
        Forward,
        Left,
        Right,
        Back,
    }
    
    private InputActions _inputActions;
    private Rigidbody _rigidbody;

    private Dictionary<Direction, bool> _inputPressed;
    
    private float _currentStrafeSpeed;
    private float _currentMovementSpeed;
    private float _rotation;

    private CheckOnGround _groundedCheck;

    private bool _isWalking = false;
    [SerializeField] 
    private float _walkProgress = 0.0f;
    [SerializeField]
    private float _walkProgressSpeed = 0.05f;
    
    [SerializeField]
    private GameObject _feetObject;
    
    [SerializeField, Min(0)]
    private float strafeSpeed;
    [SerializeField, Min(0)]
    private float movementSpeed;
    [SerializeField, Min(0)]
    private float jumpForce;
    [SerializeField, Min(0)]
    private float footStepRadius = 1.0f;

    public void Awake()
    {
        _groundedCheck = _feetObject.GetComponent<CheckOnGround>();
        _inputActions = new InputActions();
        _rigidbody = GetComponent<Rigidbody>();
        _inputPressed = new Dictionary<Direction, bool>();

        _rotation = transform.rotation.y;
        _inputActions.Player.Look.performed += ctx =>
        {
            var lookStrength = ctx.ReadValue<Vector2>();
            lookStrength *= Time.timeScale;
            _rotation += lookStrength.x * 0.25f;
            transform.rotation = Quaternion.Euler(0, _rotation % 360, 0);
        };
        ResetInput();
    }

    private void ResetInput()
    {
        _inputPressed[Direction.Forward] = false;
        _inputPressed[Direction.Left] = false;
        _inputPressed[Direction.Right] = false;
        _inputPressed[Direction.Back] = false;
    }

    private void ConfigInputSpeed()
    {
        float previousMovementSpeed = _currentMovementSpeed;
        _currentMovementSpeed = movementSpeed * (Convert.ToInt32(_inputPressed[Direction.Forward]) -
                                                 Convert.ToInt32(_inputPressed[Direction.Back]));
        
        float previousStrafeSpeed = _currentStrafeSpeed;
        _currentStrafeSpeed = strafeSpeed * (Convert.ToInt32(_inputPressed[Direction.Right]) -
                                             Convert.ToInt32(_inputPressed[Direction.Left]));

        if(_currentMovementSpeed > 0.001 ||
           _currentStrafeSpeed > 0.001)
        {
            if (!_isWalking)
            {
                Step();
            }
            _isWalking = true;
        }
        else
        {
            if (_isWalking)
            {
                Step();
            }
            _isWalking = false;
        }
    }

    void Step()
    {
        NoiseGenerator.Spawn(_feetObject.transform.position + Vector3.up * 0.05f, footStepRadius);
    }
    public void Start()
    {
        _inputActions.Player.Forward.performed += ctx =>
        {
            _inputPressed[Direction.Forward] = ctx.action.IsPressed();
            ConfigInputSpeed();
        };
        _inputActions.Player.Left.performed += ctx =>
        {
            _inputPressed[Direction.Left] = ctx.action.IsPressed();
            ConfigInputSpeed();
        };
        _inputActions.Player.Right.performed += ctx =>
        {
            _inputPressed[Direction.Right] = ctx.action.IsPressed();
            ConfigInputSpeed();
        };
        _inputActions.Player.Back.performed += ctx =>
        {
            _inputPressed[Direction.Back] = ctx.action.IsPressed();
            ConfigInputSpeed();
        };
        _inputActions.Player.Jump.performed += ctx =>
        {
            Jump();
        };
    }
    
    public void OnEnable()
    {
        _inputActions.Enable();
    }

    public void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Jump()
    {
        if (_groundedCheck.IsTouchingGround())
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
            NoiseGenerator.Spawn(_feetObject.transform.position + Vector3.up * 0.05f, footStepRadius);
        }
    }
    
    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (_currentMovementSpeed * Time.fixedDeltaTime));
        transform.Translate(Vector3.right * (_currentStrafeSpeed * Time.fixedDeltaTime));
        if (_isWalking)
        {
            _walkProgress += _walkProgressSpeed;
            if (_walkProgress > 1.0f)
            {
                _walkProgress = 0.0f;
                Step();
            }
        }
    }
}
