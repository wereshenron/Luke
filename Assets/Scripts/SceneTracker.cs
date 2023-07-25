/**

@class SceneTracker
@brief This script is used to save the scene number so when the level is restarted it does not go back to the beginning of the game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The SceneTracker class is responsible for keeping track of the previous scene index in a persistent object that does not get destroyed between scene changes.
/// </summary>
public class SceneTracker : MonoBehaviour
{
    /// <summary>
    /// Stores the index of the previously loaded scene.
    /// </summary>
    public static int previousSceneIndex = 1;

    /// <summary>
/// Ensures the SceneTracker game object is not destroyed when loading a new scene.
/// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Sets the previousSceneIndex to the current scene index at the start of the game, if the current scene is within the defined range (1 to 5).
    /// </summary>
    private void Start()
    {
        // Get the index of the currently active scene
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        // Check if the current scene index is within the defined range (1 to 5); Add more if more scenes are added
        if (currentScene == 1 || currentScene == 2 || currentScene == 3 || currentScene == 4 || currentScene == 5)
        {
            // Update the previousSceneIndex with the current scene index
            previousSceneIndex = currentScene;
        }
    }
}
