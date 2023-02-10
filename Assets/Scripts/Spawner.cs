using UnityEngine;

public class Spawner : MonoBehaviour
{
    enum State
    {
        Uninitialized,
        SpawningFinite,
        SpawningInfinite,
        Complete,
    }
    
    [SerializeField] private GameObject spawnObject;
    [SerializeField][Min(0)] private int spawnAmount = 1;
    [SerializeField][Min(0)] private float spawnSpeed = 1.0f;

    [ReadOnlyInspector, SerializeField] private int _currentSpawn;
    [ReadOnlyInspector, SerializeField] private State _currentState = State.Uninitialized;
    void Start()
    {
        _currentSpawn = 0;
        if (spawnObject)
        {
            _currentState = spawnAmount == 0 ? State.SpawningInfinite : State.SpawningFinite;
            InvokeRepeating(nameof(SpawnObject), 0.0f, spawnSpeed);
        }
    }

    void SpawnObject()
    {
        Instantiate(spawnObject, transform);
        _currentSpawn++;
        if (_currentSpawn == spawnAmount)
        {
            CancelInvoke(nameof(SpawnObject));
            _currentState = State.Complete;
        }
    }
}
