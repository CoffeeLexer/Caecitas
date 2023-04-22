using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Transform Spawn;
    private Transform Empty;

    private void Awake()
    {
        Global.Hand = this;
        foreach (Transform child in transform)
        {
            if (child.name.ToLower().Contains("spawn"))
                Spawn = child;
            if (child.name.ToLower().Contains("empty"))
                Empty = child;
        }
        if(!Spawn)
            Debug.LogWarning("Hand does NOT have 'spawn' child for spawn transform");
        if(!Empty)
            Debug.LogWarning("Hand does NOT have 'empty' child for model");
    }

    public void Hold(Item item)
    {
        Transform itemTransform = item.transform;

        if (!item)
        {
            Empty.gameObject.SetActive(true);
            itemTransform = Empty;
        }
        else
            Empty.gameObject.SetActive(false);
        
        itemTransform.SetParent(transform);
        itemTransform.SetLocalPositionAndRotation(Spawn.localPosition, Quaternion.Euler(item.heldRotation));
        itemTransform.AddComponent<MoveToOrigin>();

        if (item == Empty) return;
        
        item.SetHeldState(true);
    }
}
