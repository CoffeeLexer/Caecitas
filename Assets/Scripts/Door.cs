using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : Interactable
{
    [SerializeField] private Keyhole keyhole;
    [SerializeField] private int seekingState;
    private Animator _animator;
    protected override void OnInteractionPassed()
    {
        int state = _animator.GetInteger("State");
        if (state != seekingState)
        {
            _animator.SetInteger("State", -state.CompareTo(seekingState));
        }
    }
    
    protected virtual void Awake()
    {
        base.Awake();
        
        _animator = transform.parent.parent.GetComponent<Animator>();
        
        _requirement = new Requirement();
        _requirement.SetCheck(() => !keyhole.IsLocked);
    }
}
