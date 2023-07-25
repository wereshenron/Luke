using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ExitItemTests
{
    private ExitItem CreateExitItemObject()
    {
        GameObject exitItemObject = new GameObject();
        ExitItem exitItem = exitItemObject.AddComponent<ExitItem>();
        exitItemObject.AddComponent<BoxCollider2D>().isTrigger = true;

        return exitItem;
    }

    [UnityTest]
    public IEnumerator TestPlayerTriggerExitItem()
    {
        GameObject player = new GameObject();
        player.tag = "Player";
        player.AddComponent<BoxCollider2D>().isTrigger = true;
        player.AddComponent<Rigidbody2D>().gravityScale = 0;

        ExitItem exitItem = CreateExitItemObject();

        int initialSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Physics2D.autoSimulation = false;
        player.transform.position = exitItem.transform.position;
        Physics2D.Simulate(0.1f);
        yield return null;

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Assert.AreEqual(initialSceneIndex, newSceneIndex - 1);
    }
}
