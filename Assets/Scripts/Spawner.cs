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
    
    [SerializeField][Min(0)] private int spawnAmount = 1;
    [SerializeField][Min(0)] private float spawnSpeed = 1.0f;
    [SerializeField][Min(0)] private float spawnRadius = 1.0f;

    [ReadOnlyInspector, SerializeField] private int _currentSpawn;
    [ReadOnlyInspector, SerializeField] private State _currentState = State.Uninitialized;
    void Start()
    {
        _currentSpawn = 0;
        _currentState = spawnAmount == 0 ? State.SpawningInfinite : State.SpawningFinite;
        InvokeRepeating(nameof(SpawnObject), 1.0f, spawnSpeed);
    }

    void SpawnObject()
    {
        NoiseGenerator.Spawn(transform.position, spawnRadius);
    }
}
