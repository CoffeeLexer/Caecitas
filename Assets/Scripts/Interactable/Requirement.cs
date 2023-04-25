using System;
using UnityEngine;

public class Requirement
{
    public bool State => _check();
    private Func<bool> _check;

    public void SetCheck(Func<bool> check)
    {
        _check = check;
    }
}