using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    protected abstract void OnLook();
    protected abstract void OnLookAway();
    protected abstract void OnInteract(CameraPointer ptr);

    public void Look() => OnLook();
    public void LookAway() => OnLookAway();
    public void Interact(CameraPointer ptr) => OnInteract(ptr);

    [SerializeField] private string _text;

    public string Text
    {
        get => _text;
        private set => _text = value;
    }
}