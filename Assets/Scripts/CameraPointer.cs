using UnityEngine;
using UnityEngine.UI;

public class CameraPointer : MonoBehaviour
{
    private Interactive _focusedObject;
    private InputActions _inputActions;

    [SerializeField] private Text ui;
    
    private void Start()
    {
        _focusedObject = null;
        _inputActions = new InputActions();
        _inputActions.Player.Interact.Enable();
        _inputActions.Player.Interact.performed += ctx => Interact();
    }

    private void FixedUpdate()
    {
        Interactive newFocus = null;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.transform.TryGetComponent<Interactive>(out var interactive))
            {
                newFocus = interactive;
            }
        }
        SetFocus(newFocus);
    }

    private void SetFocus(Interactive interactive)
    {
        if (_focusedObject == interactive)
            return;

        if (_focusedObject)
            _focusedObject.LookAway();

        ui.text = string.Empty;
        _focusedObject = interactive;

        if (_focusedObject)
        {
            _focusedObject.Look();
            ui.text = _focusedObject.Text;
        }
    }

    private void Interact()
    {
        if(_focusedObject) _focusedObject.Interact();
    }
}