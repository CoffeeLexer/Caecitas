using System.Collections;
using UnityEngine;

public class SoundBehavior : MonoBehaviour
{
    private static readonly int ColorID = Shader.PropertyToID("_Color");
    
    private float _diameter;

    private Material _material;
    private Color _color;

    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _color = _material.GetColor(ColorID);
        StartCoroutine(Progress());
    }

    public void Travel(float radius)
    {
        _diameter = radius * 2;
    }
    
    IEnumerator Progress()
    {
        for(float current = 0; current < _diameter; current += Global.Objects.soundSpeed * Time.deltaTime)
        {
            float progress = current / _diameter;
            transform.localScale = Vector3.one * current;
            _color.a = 1.0f - progress;
            _material.SetColor(ColorID, _color);
            yield return null;
        }
        _color.a = 0.0f;
        _material.SetColor(ColorID, _color);
        Destroy(gameObject);
    }
}
