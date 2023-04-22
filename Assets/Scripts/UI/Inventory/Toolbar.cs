using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    private InputActions _inputActions;
    [SerializeField] private int _current;

    void Awake()
    {
        Global.Toolbar = this;
        
        slots = GetComponentsInChildren<Slot>().ToList();
        _current = 0;

        _inputActions = new InputActions();
        _inputActions.Player.Scroll.Enable();
        _inputActions.Player.Scroll.performed += ctx =>
        {
            Vector2 delta = ctx.ReadValue<Vector2>();
            slots[_current].SetIsCurrent(false);
            int change = delta.y < 0 ? -1 : +1;
            _current = (_current + change + slots.Count) % slots.Count;
            slots[_current].SetIsCurrent(true);
        };
        
        if(slots.Count > 0)
            slots[_current].SetIsCurrent(true);
        else
        {
            Debug.LogWarning("No slots!");
        }
    }

    private int FindEmptySlot()
    {
        if (slots[_current].IsEmpty()) return _current;
        
        for (int i = (_current + 1) % slots.Count; i != _current; i = (i + 1) % slots.Count)
            if (slots[i].IsEmpty()) return i;

        return -1;
    }

    public bool TakeItem(Item item)
    {
        int index = FindEmptySlot();
        if (index == -1) return false;
        slots[index].SetItem(item);
        
        Global.Hand.Hold(item);
        Global.Notification.Set($"Picked up {item.name}");

        return true;
    }
}