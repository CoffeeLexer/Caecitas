using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private static Hand _instance;
    
    private Transform _spawnPivot;
    private Transform _emptyHand;
    private Item _heldItem;

    public static Item Item => _instance._heldItem;

    private void Awake()
    {
        _instance = Global<Hand>.Bind(this);
        
        foreach (Transform child in transform)
        {
            if (child.name.ToLower().Contains("spawn"))
            {
                _spawnPivot = child;
            }

            if (child.name.ToLower().Contains("empty"))
            {
                _emptyHand = child;
            }
        }

        if (!_spawnPivot)
        {
            Debug.LogWarning("Hand does NOT have 'spawn' child for spawn transform");
        }

        if (!_emptyHand)
        {
            Debug.LogWarning("Hand does NOT have 'empty' child for model");
        }
    }

    public static void Hold(Item item) => _instance.hold(item);
    private void hold(Item item)
    {
        if (_heldItem == item) // No Change
        {
            return;
        }

        GameObject itemObject = _heldItem ? _heldItem.gameObject : _emptyHand.gameObject;
        itemObject.SetActive(false);
        
        _heldItem = item;
        
        if (_heldItem)
        {
            _heldItem.SetHeldState(true);
        }
        else
        {
            Inventory.EmptyTheHand();
        }

        Transform itemTransform = _heldItem ? _heldItem.transform : _emptyHand;

        // Move from bottom to view
        itemTransform.transform.gameObject.SetActive(true);
        itemTransform.SetParent(transform);
        if (item)
        {
            itemTransform.SetLocalPositionAndRotation(_spawnPivot.localPosition, Quaternion.Euler(item.heldRotation));
        }
        else
        {
            itemTransform.SetLocalPositionAndRotation(_spawnPivot.localPosition, _emptyHand.localRotation);
        }
        itemTransform.AddComponent<MoveToOrigin>();
    }
    
    public static void Drop() => _instance.drop();
    private void drop()
    {
        if (!_heldItem)
            return;

        var moveToOrigin = _heldItem.GetComponent<MoveToOrigin>();
        if (moveToOrigin)
        {
            Destroy(moveToOrigin);
        }
        
        var rb = _heldItem.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        
        _heldItem.transform.SetParent(null);
        _heldItem.transform.transform.position = Player.GetPutPosition();
        _heldItem.SetHeldState(false);

        _heldItem = null;
    }

    public static void Throw() => _instance.mThrow();
    private void mThrow()
    {
        if (!_heldItem)
            return;
        
        var moveToOrigin = _heldItem.GetComponent<MoveToOrigin>();
        if (moveToOrigin)
        {
            Destroy(moveToOrigin);
        }

        _heldItem.transform.SetParent(null);
        _heldItem.transform.transform.position = Player.GetPutPosition();
        _heldItem.SetHeldState(false);

        var rb = _heldItem.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        var throwForce = Player.GetThrowDirection() * Global.Objects.throwForce;
        rb.AddForce(throwForce);
        
        _heldItem = null;
    }
    
    public static Vector3 GetOffset() => _instance.getOffset();
    private Vector3 getOffset()
    {
        return transform.position - transform.parent.position;
    }

    public static void DestroyItem() => _instance.destroyItem();
    private void destroyItem()
    {
        var temp = _heldItem;
        hold(null);
        Destroy(temp.gameObject);
    }
}
