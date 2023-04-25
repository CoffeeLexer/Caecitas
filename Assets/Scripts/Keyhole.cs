
using System;
using UnityEngine;

public class Keyhole : Interactable
{
    [SerializeField] private Item key;
    [SerializeField] private bool _isLocked = false;

    public bool IsLocked => _isLocked;
    
    protected void Awake()
    {
        base.Awake();
        if (_isLocked)
        {
            _requirement = new Requirement();
            _requirement.SetCheck(() => key == Hand.Item);
        }
    }

    public override string Text
    {
        get
        {
            if (!_isLocked)
                return "Keyhole Unlocked";
            if (_requirement.State)
                return "Unlock door";
            return "Keyhole (Locked)";
        }
        protected set => _text = value;
    }

    protected override void OnInteractionPassed()
    {
        Hand.DestroyItem();
        _isLocked = false;
        
        NoiseGenerator.Spawn(transform.position, 1.5f);
    }
}