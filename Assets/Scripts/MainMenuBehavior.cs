/**

@class MainMenuBehavior
@brief This script is used to navigate the main menu and define the behavior of the buttons on it
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pausebutton;

    private void NewGame() { // Behavior for the new game button. 
        SceneManager.LoadScene("Introduction"); // Currently loads scene 1 but needs to be changed to correct scene number at some date.
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }

    private void StartGame() {
        SceneManager.LoadScene("Neighborhood"); // Behavior for the start game button.
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }

    private void LoadGame() { // Behavior for the load game button.
        SceneManager.LoadScene("LoadGame"); // Loads another scene to inout save game data.
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }

    private void Settings() { // Behavior for the settings button.
        SceneManager.LoadScene("Settings"); // Loads settings for now but may be removed.
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }

    private void CreditsButton() { // Behavior for the credits button.
        SceneManager.LoadScene("Credits"); // Loads to the credits 
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }

    private void BackButton() { // Behavior for the back button.
        SceneManager.LoadScene(0); // Loads back to main menu
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }

    private void QuitGame() {
        Application.Quit(); // Purpose is to quit the game.
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // play clicking sound effect using PlayOneShot()
    }


    /// <summary>
    /// Mute and unmute all in game audio
    /// </summary>
    public void MuteButton() { // Mute and unmute all in game audio
        AudioListener.pause = true;
    } 
    
    /// <summary>
    /// Mute and unmute all in game audio
    /// </summary>
    public void UnMuteButton() {
        AudioListener.pause = false;

    }

    private void PauseButton() // Pause button, freezes time.
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _pausebutton.SetActive(false);
    }

    private void ResumeButton() // Resume button, sets time scale back to normal.
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        _pausebutton.SetActive(true);
    }
}

