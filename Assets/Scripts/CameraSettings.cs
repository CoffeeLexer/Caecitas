using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public void Start()
    {
        var camera = GetComponent<Camera>();
        camera.depthTextureMode = DepthTextureMode.DepthNormals;
    }
}
