using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance = null;

    public Vector3 _putPosition;
    public Vector3 _throwDirection;

    private void Awake()
    {
        _instance = Global<Player>.Bind(this);
    }

    public static Vector3 GetPosition()
    {
        return _instance.getPosition();
    }

    private Vector3 getPosition()
    {
        return Camera.main.transform.transform.position + Hand.GetOffset();
    }

    public static void SetPutPosition(Vector3 v)
    {
        _instance.setPutPosition(v);
    }

    private void setPutPosition(Vector3 v)
    {
        _putPosition = v;
    } 
    
    public static Vector3 GetPutPosition()
    {
        return _instance.getPutPosition();
    }

    private Vector3 getPutPosition()
    {
        return _putPosition;
    } 

    public static bool Equals(GameObject obj) => obj == _instance.gameObject;
    
    public static void SetThrowDirection(Vector3 v)
    {
        _instance.setThrowDirection(v);
    }

    private void setThrowDirection(Vector3 v)
    {
        _throwDirection = v;
    } 
    
    public static Vector3 GetThrowDirection()
    {
        return _instance.getThrowDirection();
    }

    private Vector3 getThrowDirection()
    {
        return _throwDirection;
    } 
}