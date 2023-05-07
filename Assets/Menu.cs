using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] 
    private GameObject _optionsPanel;
    [SerializeField] 
    private GameObject _levelPanel;

    [SerializeField] 
    private bool _isMainMenu = false;
    
    private InputActions _inputActions;
    private bool paused;
    private bool inLevelSelection;
    
    void Start()
    {
        
        _inputActions = new InputActions();
        _inputActions.Player.Menu.performed += ctx =>
        {
            if (inLevelSelection)
            {
                CloseLevelSelection();
                return;
            }

            if (_isMainMenu)
            {
                return;
            }
            
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        };
        _inputActions.Player.Menu.Enable();

        if (!_isMainMenu)
        {
            ResumeGame();
        }
    }
    
    public void PauseGame ()
    {
        inLevelSelection = false;
        paused = true;
        Time.timeScale = 0;
        PlayerCamera.setActive(false);
        _optionsPanel.SetActive(true);
        _levelPanel.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void ResumeGame ()
    {
        inLevelSelection = false;
        paused = false;
        Time.timeScale = 1;
        PlayerCamera.setActive(true);
        _optionsPanel.SetActive(false);
        _levelPanel.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SelectPuzzle()
    {
        // Remove Menu -> Wont allow will ignore ESC button
        Destroy(gameObject);
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
    
    public void SelectPlatform()
    {
        // Remove Menu -> Wont allow will ignore ESC button
        Destroy(gameObject);
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
    
    public void SelectMaze()
    {
        // Remove Menu -> Wont allow will ignore ESC button
        Destroy(gameObject);
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(3);
        });
    }

    public void OpenLevelSelection()
    {
        inLevelSelection = true;
        _optionsPanel.SetActive(false);
        _levelPanel.SetActive(true);
    }
    
    public void CloseLevelSelection()
    {
        inLevelSelection = false;
        _optionsPanel.SetActive(true);
        _levelPanel.SetActive(false);
    }

    public void ResetLevel()
    {
        // Remove Menu -> Wont allow will ignore ESC button
        Destroy(gameObject);
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    public void GoMainMenu()
    {
        // Remove Menu -> Wont allow will ignore ESC button
        Destroy(gameObject);
        Overlay.FadeOut(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    public void QuitGame()
    {
        // Remove Menu -> Wont allow will ignore ESC button
        Destroy(gameObject);
        Overlay.FadeOut(() =>
        {
            Application.Quit();
        });
    }

    public void debug()
    {
        Debug.Log("debug() Invoked");
    }
}
