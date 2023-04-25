
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class InvokeZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;
    private void OnTriggerEnter(Collider other)
    {
        if (Player.Equals(other.gameObject))
        {
            _event.Invoke();
        }
    }

    private void Awake()
    {
        if (_event == null)
        {
            Debug.Log("No Invoke Event is set!");
            gameObject.SetActive(false);
        }
    }
}
