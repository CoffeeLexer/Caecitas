using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    private static Notification _instance;

    private Text _text;
    private Color _color;
    
    private void Awake()
    {
        _instance = Global<Notification>.Bind(this);

        _text = GetComponent<Text>();
        _color = _text.color;
        _color.a = 0f;
        _text.color = _color;
    }

    public static void Notify(string text) => _instance.notify(text);
    private void notify(string text)
    {
        _text.text = text;
        StopAllCoroutines();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color c = _color;
        for (float alpha = 2f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = MathF.Min(alpha, 1.0f);
            _text.color = c;
            yield return new WaitForSeconds(.1f);
        }

        c.a = 0;
        _text.color = c;
    }
}
