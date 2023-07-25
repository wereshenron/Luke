using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class SceneTrackerTests
{
    [Test]
    public void PreviousSceneIndexUpdated()
    {
        // Create a SceneTracker object
        GameObject sceneTrackerObj = new GameObject("SceneTracker");
        SceneTracker sceneTracker = sceneTrackerObj.AddComponent<SceneTracker>();

        // Set the current scene index to 3
        SceneManager.LoadScene(3, LoadSceneMode.Single);

        // Check if the previousSceneIndex is updated correctly
        Assert.AreEqual(3, SceneTracker.previousSceneIndex);
    }
}
