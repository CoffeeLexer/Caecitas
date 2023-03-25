using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactive
{
    protected override void OnLook()
    {
        Debug.Log("Item Looked");
    }

    protected override void OnLookAway()
    {
        Debug.Log("Item Looked Away");
    }

    protected override void OnInteract()
    {
        Debug.Log("Item Interact");
    }
}