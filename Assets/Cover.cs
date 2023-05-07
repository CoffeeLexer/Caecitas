using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cover : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _startEvent;
    [SerializeField] 
    private UnityEvent _fadeInEvent;
    [SerializeField]
    private UnityEvent _fadeOutEvent;
    
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
        _startEvent?.Invoke();
    }

    public void FadeOut()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOutRoutine());
    }
    
    public void FadeIn()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        Color c = _image.color;
        for (float alpha = 1.25f; alpha >= 0.25; alpha -= 0.02f)
        {
            c.a = Mathf.Min(alpha, 1.0f) ;
            _image.color = c;
            yield return null;
        }
        gameObject.SetActive(false);
        _fadeInEvent.Invoke();
    }
    IEnumerator FadeOutRoutine()
    {
        Color c = _image.color;
        for (float alpha = -0.25f; alpha <= 1.25; alpha += 0.02f)
        {
            c.a = Mathf.Max(alpha, 0.0f) ;
            _image.color = c;
            yield return null;
        }
        gameObject.SetActive(false);
        _fadeOutEvent.Invoke();
    }
}
