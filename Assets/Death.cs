using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Player.Equals(other.gameObject))
        {
            Overlay.SetColor(Color.red);
            Overlay.SetText("You have Died");
            Overlay.FadeOut(() =>
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                Resources.UnloadUnusedAssets();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            });
        }
    }
}
