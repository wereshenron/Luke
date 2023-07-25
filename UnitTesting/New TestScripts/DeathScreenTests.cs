using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class DeathScreenTests
{
    private DeathScreen CreateDeathScreenObject()
    {
        GameObject deathScreenObject = new GameObject();
        DeathScreen deathScreen = deathScreenObject.AddComponent<DeathScreen>();
        deathScreenObject.AddComponent<GameObject>();

        return deathScreen;
    }

    [UnityTest]
    public IEnumerator TestRestart()
    {
        DeathScreen deathScreen = CreateDeathScreenObject();
        SceneTracker.previousSceneIndex = 1;

        deathScreen.Restart();
        yield return null;

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Assert.AreEqual(1, newSceneIndex);
    }

    [UnityTest]
    public IEnumerator TestMainMenu()
    {
        DeathScreen deathScreen = CreateDeathScreenObject();

        deathScreen.MainMenu();
        yield return null;

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Assert.AreEqual(0, newSceneIndex);
    }
}
