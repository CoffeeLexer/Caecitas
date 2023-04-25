using System;
using UnityEngine;
using UnityEngine.UI;

public class Identifier : MonoBehaviour
{
    private static Identifier _instance;

    private Text _text;
    private void Awake()
    {
        _instance = Global<Identifier>.Bind(this);
        _text = GetComponent<Text>();
    }

    public static void SetText(string text) => _instance.setText(text);

    private void setText(string text)
    {
        _text.text = text;
    }
}