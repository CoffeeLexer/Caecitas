using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DestroyOnTrigger : MonoBehaviour
{
    public string tagToDestroy = "Tag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToDestroy))
        {
            Destroy(other.gameObject);
        }
    }
}