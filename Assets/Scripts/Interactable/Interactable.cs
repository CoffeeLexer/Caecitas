
using System;
using UnityEngine;

public class Interactable : Interactive
{
    protected Requirement _requirement = null;

    [SerializeField] 
    protected string requirementFailedText;
    [SerializeField] 
    protected string requirementNotMet;
    
    protected override void OnInteract()
    {
        if (_requirement == null)
        {
            OnInteractionPassed();
        }
        else
        {
            if (_requirement.State)
            {
                OnInteractionPassed();
            }
            else
            {
                Notification.Notify(requirementFailedText);
            }
        }
    }

    protected virtual void Awake()
    {
        base.Awake();
    }
    
    public override string Text
    {
        get => _requirement.State ? base.Text : requirementNotMet;
        protected set => base.Text = value;
    }

    protected virtual void OnInteractionPassed()
    {
        
    }
}
