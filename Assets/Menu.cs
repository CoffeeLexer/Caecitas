using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private InputActions _inputActions;
    private bool paused;
    private GameObject _childPanel;
    
    void Start()
    {
        _childPanel = transform.GetChild(0).gameObject;
        
        _inputActions = new InputActions();
        _inputActions.Player.Menu.performed += ctx =>
        {
            if (paused)
            {
                ResumeGame();
                paused = false;
            }
            else
            {
                PauseGame();
                paused = true;
            }
        };
        _inputActions.Player.Menu.Enable();
    }
    
    public void PauseGame ()
    {
        Time.timeScale = 0;
        PlayerCamera.setActive(false);
        _childPanel.SetActive(true);
    }
    
    public void ResumeGame ()
    {
        Time.timeScale = 1;
        PlayerCamera.setActive(true);
        _childPanel.SetActive(false);
    }

    public void ResetLevel()
    {
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    public void GoMainMenu()
    {
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
