using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsTicking", true);
    }

    public void Tick()
    {
        Global.NoiseGenerator.Spawn(transform.position, 1);
        Debug.Log("Tick");
    }
}
