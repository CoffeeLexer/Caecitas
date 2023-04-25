using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;

    private InputActions _inputActions;
    private List<Slot> _slots;
    private int _current;

    private void Awake()
    {
        _instance = Global<Inventory>.Bind(this);
        
        _inputActions = new InputActions();
        _inputActions.Player.Scroll.Enable();
        _inputActions.Player.Scroll.performed += ctx =>
        {
            Vector2 delta = ctx.ReadValue<Vector2>();
            _slots[_current].SetIsCurrent(false);
            int change = delta.y < 0 ? -1 : +1;
            _current = (_current + change + _slots.Count) % _slots.Count;
            _slots[_current].SetIsCurrent(true);
        };
        
        _inputActions.Player.Drop.Enable();
        _inputActions.Player.Drop.performed += ctx =>
        {
            _slots[_current].SetItem(null);
            Hand.Drop();
        };
        
        _inputActions.Player.Throw.Enable();
        _inputActions.Player.Throw.performed += ctx =>
        {
            _slots[_current].SetItem(null);
            Hand.Throw();
        };

        _slots = new List<Slot>();
    }
    public void OnEnable()
    {
        _inputActions.Enable();
    }

    public void OnDisable()
    {
        _inputActions.Disable();
    }

    public static bool Take(Item item) => _instance.take(item);

    private bool take(Item item)
    {
        int index = findEmptySlot();
        if (index == -1)
        {
            Notification.Notify($"Inventory FULL");
            return false;
        }
        _slots[index].SetItem(item);
        
        Hand.Hold(item);
        Notification.Notify($"Picked up {item.name}");

        return true;
    }

    public static void AddSlot(Slot slot) => _instance.addSlot(slot);

    private void addSlot(Slot slot)
    {
        if (_slots.Count == 0)
        {
            slot.SetIsCurrent(true);
        }
        _slots.Add(slot);
    }
    
    private int findEmptySlot()
    {
        if (_slots[_current].IsEmpty()) return _current;

        int Next(int x) => (x + 1) % _slots.Count;

        for (int i = Next(_current); i != _current; i = Next(i))
            if (_slots[i].IsEmpty()) return i;

        return -1;
    }
}