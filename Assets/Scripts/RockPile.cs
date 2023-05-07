
using System;
using UnityEngine;

public class RockPile : Interactive
{
    [SerializeField] 
    private GameObject _rock;
    private void Awake()
    {
        base.Awake();
        Text = "Take rock";
        if (!_rock)
        {
            Debug.Log("ROCK IS NOT ATTACHED");
        }
    }

    protected override void OnInteract()
    {
        if (_rock)
        {
            var obj = Instantiate(_rock);
            var item = obj.GetComponent<Item>();
            Inventory.Take(item);
        }
    }
}
