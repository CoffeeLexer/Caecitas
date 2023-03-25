using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class Blurred : MonoBehaviour
{
    private Material _material;
    private Camera _camera;
    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _camera = Camera.main;
    }

    void Update()
    {
        _material.mainTexture = RTImage();
    }
    private Texture2D RTImage()
    {
        var currentCamera = _camera;
        Rect rect = new Rect(0, 0, currentCamera.pixelWidth, currentCamera.pixelHeight);
        RenderTexture renderTexture = new RenderTexture(currentCamera.pixelWidth, currentCamera.pixelHeight, 24);
        Texture2D screenShot = new Texture2D(currentCamera.pixelWidth, currentCamera.pixelHeight, TextureFormat.RGBA32, false);
 
        currentCamera.targetTexture = renderTexture;
        currentCamera.Render();
 
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();
 
        currentCamera.targetTexture = null;
        RenderTexture.active = null;
 
        Destroy(renderTexture);
        return screenShot;
    }
}
