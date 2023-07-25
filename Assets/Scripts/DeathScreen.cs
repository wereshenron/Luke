/**

@class DeathScreen
@brief This controls the behavior of the Death Screen that pops up when the player dies
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pausebutton;

    /// <summary>
    /// Restarts the game by loading the previous scene.
    /// </summary>
    public void Restart()
    {
    SceneManager.LoadScene(SceneTracker.previousSceneIndex);
    }

    /// <summary>
    /// Returns the player to the main menu scene.
    /// </summary>
    public void MainMenu() { // Behavior for the back button.
        SceneManager.LoadScene(0); // Loads back to main menu
        
    }

    /// <summary>
    /// Quits the game application.
    /// </summary>
    private void QuitGame() {
        Application.Quit(); // Purpose is to quit the game.
    }

    /// <summary>
    /// Pauses the game and displays the pause menu.
    /// </summary>
    private void PauseButton()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _pausebutton.SetActive(false);
    }

    /// <summary>
    /// Resumes the game and hides the pause menu.
    /// </summary>
    private void ResumeButton()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        _pausebutton.SetActive(true);
    }
}

