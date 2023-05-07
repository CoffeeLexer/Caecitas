using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ReplacementShaderEffect : MonoBehaviour
{
    [SerializeField] 
    private Shader _replacement;

    private void OnEnable()
    {
        if(!_replacement) return;
        GetComponent<Camera>().SetReplacementShader(_replacement, "");
    }

    private void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }
}
