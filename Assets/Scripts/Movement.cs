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
    private Queue<GameObject> _feetQueue;
    

    [SerializeField, Min(0)] private float strafeSpeed;
    [SerializeField, Min(0)] private float movementSpeed;
    [SerializeField, Min(0)] private float jumpForce;
    [SerializeReference] private GameObject[] feet;
    [SerializeReference] private GameObject footPrefab;

    public void Awake()
    {
        _feetQueue = new Queue<GameObject>();
        foreach (var foot in feet)
        {
            _feetQueue.Enqueue(foot);
        }
        
        _inputActions = new InputActions();
        _rigidbody = GetComponent<Rigidbody>();
        _inputPressed = new Dictionary<Direction, bool>();

        _rotation = transform.rotation.y;
        _inputActions.Player.Look.performed += ctx =>
        {
            var lookStrength = ctx.ReadValue<Vector2>();
            _rotation += lookStrength.x;
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
        float temporary = _currentMovementSpeed;
        _currentMovementSpeed = movementSpeed * (Convert.ToInt32(_inputPressed[Direction.Forward]) -
                                                 Convert.ToInt32(_inputPressed[Direction.Back]));

        bool stepRequired = Math.Abs(temporary - _currentMovementSpeed) > 0.001;

        temporary = _currentStrafeSpeed;
        _currentStrafeSpeed = strafeSpeed * (Convert.ToInt32(_inputPressed[Direction.Right]) -
                                             Convert.ToInt32(_inputPressed[Direction.Left]));
        
        if(stepRequired || Math.Abs(temporary - _currentMovementSpeed) > 0.001) Step();
    }

    void Step()
    {
        if (_feetQueue.Count == 0 || footPrefab == null) return;
        
        GameObject foot = _feetQueue.Dequeue();
        _feetQueue.Enqueue(foot);
        
        Instantiate(footPrefab, foot.transform.position, foot.transform.rotation);
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
        _rigidbody.AddForce(Vector3.up * jumpForce);
    }
    
    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (_currentMovementSpeed * Time.fixedDeltaTime));
        transform.Translate(Vector3.right * (_currentStrafeSpeed * Time.fixedDeltaTime));
    }
}
