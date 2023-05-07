using System;
using System.Collections;
using UnityEngine;

public class Pulsating : MonoBehaviour
{
   [SerializeField, Min(0)]
   private float maximumPulsation;

   [SerializeField] 
   private float speed = 0.5f;

   private Vector3 defaultScale;

   private Vector3 Scale
   {
      get
      {
         return transform.localScale;
      }
      set
      {
         transform.localScale = defaultScale + value;
      }
   }
   
   private void Awake()
   {
      defaultScale = transform.localScale;

      StartCoroutine(Pulsate());
   }
   
   IEnumerator Pulsate()
   {
      float progress = 0;
      float target = maximumPulsation / 2;
      
      for (;;)
      {
         progress += Time.fixedDeltaTime * speed;
         progress %= 360;

         Scale = Vector3.one * (target + target * Mathf.Sin(Mathf.Deg2Rad * progress));
         yield return null;
      }
   }
}