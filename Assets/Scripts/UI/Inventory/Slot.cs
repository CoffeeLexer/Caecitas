using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private float _scaleMinimum = 150;
    [SerializeField] private float _scaleMaximum = 200;

    [SerializeField] private float _scaleCurrent;
    [SerializeField] private bool _isActive;
    
    [SerializeField, Range(0.0f, 1.0f)] private float _speed = 0.5f;
    
    private float _scaleTarget;
    private RectTransform _rect;
    private Item _item;
    private Image _image;

    public Item GetItem => _item;
    
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
        Inventory.AddSlot(this);
        
        _rect = GetComponent<RectTransform>();
        _image = transform.GetChild(0).GetComponent<Image>();

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
        Hand.Hold(_item);
    }

    public void SetItem(Item item)
    {
        if (item)
        {
            _image.sprite = item.SlotSprite;
            Color c = _image.color;
            c.a = 100.0f / 255.0f;
            _image.color = c;
        }
        else
        {
            _image.sprite = null;
            Color c = _image.color;
            c.a = 0;
            _image.color = c;
        }
        _item = item;
    }

    public bool IsEmpty()
    {
        return !_item;
    }
}
