using UnityEngine;

public class MoveToOrigin : MonoBehaviour
{
    private float _speed = 0.1f;

    void FixedUpdate()
    {
        var newPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, _speed);
        
        //if(newPosition == transform.position) 
            //Destroy(this);
        
        transform.localPosition = newPosition;
    }
    
    public void SetSpeed(float speed) => _speed = speed;
}
