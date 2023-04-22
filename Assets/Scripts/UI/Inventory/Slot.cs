using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private float _scaleMinimum = 100;
    [SerializeField] private float _scaleMaximum = 100;

    [SerializeField] private float _scaleCurrent;
    [SerializeField] private bool _isActive;
    
    [SerializeField, Range(0.0f, 1.0f)] private float _speed = 0.5f;
    
    private float _scaleTarget;
    private RectTransform _rect;
    private GameObject _item;
    private Sprite _defaultSprite;
    private Image _image;
    
    float ScaleCurrent
    {
        get => _scaleCurrent;
        set
        {
            _scaleCurrent = value;
            _rect.sizeDelta = new Vector2(_scaleCurrent, _scaleCurrent);
        }
    }

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _defaultSprite = _image.sprite;

        SetIsCurrent(_isActive);
        ScaleCurrent = _scaleTarget;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(ScaleCurrent - _scaleTarget) > 0.01)
        {
            ScaleCurrent = Mathf.Lerp(ScaleCurrent, _scaleTarget, _speed);
        }
    }

    public void SetIsCurrent(bool newActivity)
    {
        _isActive = newActivity;
        _scaleTarget = _isActive ? _scaleMaximum : _scaleMinimum;
    }

    public void SetItem(Item obj)
    {
        if (obj)
        {
            _image.sprite = obj.GetSlotSprite();
        }
        else
        {
            _image.sprite = _defaultSprite;
        }
    }
    
    public bool IsEmpty()
    {
        return !_item;
    }
}
