/**

@class PauseMenu
@brief This script is utilized for the pause menu buttons
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Code for all pause button related behaviors.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    
    /// <summary>
    /// Activate the pause menu and pauses the game when button is clicked
    /// </summary>
    public void Pause() { 
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Deactivate the pause menu and resumes the game, called when resume button is clicked
    /// </summary>
    public void Resume() { // Resume Button
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Exits the to main menu scene and resumes the game when clicked
    /// </summary>
    public void Home() { // Home Button
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


}
