using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    protected abstract void OnLook();
    protected abstract void OnLookAway();
    protected abstract void OnInteract();

    public void Look() => OnLook();
    public void LookAway() => OnLookAway();
    public void Interact() => OnInteract();

    [SerializeField] private string _text;

    public string Text
    {
        get => _text;
        private set => _text = value;
    }
}