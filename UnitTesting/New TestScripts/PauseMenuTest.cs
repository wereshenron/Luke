using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PauseMenuTests
{
    private PauseMenu CreatePauseMenuObject()
    {
        GameObject pauseMenuObject = new GameObject();
        PauseMenu pauseMenu = pauseMenuObject.AddComponent<PauseMenu>();
        pauseMenuObject.AddComponent<GameObject>();

        return pauseMenu;
    }

    [UnityTest]
    public IEnumerator TestPauseAndResume()
    {
        PauseMenu pauseMenu = CreatePauseMenuObject();

        pauseMenu.Pause();
        yield return null;
        Assert.AreEqual(0f, Time.timeScale);

        pauseMenu.Resume();
        yield return null;
        Assert.AreEqual(1f, Time.timeScale);
    }
}
