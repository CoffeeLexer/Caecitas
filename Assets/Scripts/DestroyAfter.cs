using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField, Min(0)] private float time;
    void Start()
    {
        Invoke(nameof(SelfDestruct), time);
    }

    void SelfDestruct()
    {
        Destroy(transform.gameObject);
    }
    public void SetTime(float newTime)
    {
        CancelInvoke();
        time = newTime;
        Invoke(nameof(SelfDestruct), time);
    }
}
