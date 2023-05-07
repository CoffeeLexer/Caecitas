using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Metronome : MonoBehaviour
{
    private Animator _animator;
    private Item _item;
    private float _period; 
    void Start()
    {
        _animator = GetComponent<Animator>();
        _item = GetComponent<Item>();
        
        _animator.SetBool("IsTicking", true);
    }

    private void FixedUpdate()
    {
        // If switched within inventory, will reset
        //if (_period == Global.Objects.metronomePeriod) return;
        _period = Global.Objects.metronomePeriod;
        _animator.SetFloat("Period", _period);
    }

    public void Tick()
    {
        if (_item.IsHeld)
        {
            NoiseGenerator.Spawn(Player.GetPosition(), Global.Objects.metronomeRadius);
        }
        else
        {
            NoiseGenerator.Spawn(transform.position, Global.Objects.metronomeRadius);
        }
    }
}
