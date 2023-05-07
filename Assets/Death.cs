using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] 
    private string deathMessage = "You have Died";
    
    private void OnTriggerEnter(Collider other)
    {
        if (Player.Equals(other.gameObject))
        {
            Overlay.SetColor(new Color(0.5f, 0, 0, 0));
            Overlay.SetText(deathMessage);
            Overlay.FadeOut(() =>
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                Resources.UnloadUnusedAssets();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            });
        }
    }
}
