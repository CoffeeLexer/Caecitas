using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class NextLevel : MonoBehaviour
{
    public void GoToNextLevel()
    {
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Player.Equals(other.gameObject))
        {
            GoToNextLevel();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (Player.Equals(collision.gameObject))
        {
            GoToNextLevel();
        }
    }
}
