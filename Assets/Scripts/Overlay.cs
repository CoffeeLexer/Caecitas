using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Overlay : MonoBehaviour
{
    private static Overlay _instance;
    private Action fadeInAction;
    private Action fadeOutAction;
    private Image selfImage;
    private Text textImage;
    private float readTime;

    private void Awake()
    {
        _instance = Global<Overlay>.Bind(this);
        
        selfImage = GetComponent<Image>();
        textImage = transform.GetChild(0).GetComponent<Text>();
        
        StartCoroutine(FadeInRoutine());
    }

    public static void FadeOut(Action action)
    {
        _instance.fadeOut(action);
    }
    
    private void fadeOut(Action action)
    {
        gameObject.SetActive(true);
        fadeOutAction = action;
        StartCoroutine(FadeOutRoutine());
    }
    
    public static void FadeIn(Action action)
    {
        _instance.fadeIn(action);
    }
   
    private void fadeIn(Action action)
    {
        gameObject.SetActive(true);
        fadeInAction = action;
        StartCoroutine(FadeInRoutine());
    }
    
    IEnumerator FadeInRoutine()
    {
        Color cSelf = selfImage.color;
        Color cText = textImage.color;
        
        for (float alpha = 1.0f; alpha > 0.0f; alpha -= 0.01f)
        {
            cSelf.a = cText.a = Mathf.Min(alpha, 1.0f) ;
            selfImage.color = cSelf;
            textImage.color = cText;
            
            yield return null;
        }

        cSelf.a = cText.a = 0.0f;
        selfImage.color = cSelf;
        textImage.color = cText;
        
        //fadeInAction.Invoke();
        gameObject.SetActive(false);
    }
    IEnumerator FadeOutRoutine()
    {
        Color cSelf = selfImage.color;
        Color cText = textImage.color;
        
        for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.01f)
        {
            cSelf.a = cText.a = Mathf.Max(alpha, 0.0f) ;
            selfImage.color = cSelf;
            textImage.color = cText;
            
            yield return null;
        }
        
        cSelf.a = cText.a = 1.0f;
        selfImage.color = cSelf;
        textImage.color = cText;
        
        fadeOutAction.Invoke();
    }

    public static void SetColor(Color c)
    {
        _instance.setColor(c);
    }

    private void setColor(Color c)
    {
        var image = GetComponent<Image>();
        Color cTemp = image.color;
        c.a = cTemp.a;
        image.color = c;
    }

    public static void SetText(string t)
    {
        _instance.setText(t);
    }

    private void setText(string t)
    {
        textImage.text = t;
    }
}