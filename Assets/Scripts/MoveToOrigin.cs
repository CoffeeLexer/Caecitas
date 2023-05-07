using UnityEngine;

[DisallowMultipleComponent] 
public class MoveToOrigin : MonoBehaviour
{
    private const float Speed = 0.1f;

    void FixedUpdate()
    {
        var newPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Speed);
        
        if(Mathf.Abs((newPosition - transform.localPosition).magnitude) < 0.001) 
            Destroy(this);
        
        transform.localPosition = newPosition;
    }
}
