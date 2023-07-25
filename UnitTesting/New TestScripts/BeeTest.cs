using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BeeTests
{
    [UnityTest]
    public IEnumerator BeeSpawnerSpawnsBees()
    {
        // Create a new GameObject and add a BeeSpawner component
        GameObject spawnerObject = new GameObject();
        BeeSpawner spawner = spawnerObject.AddComponent<BeeSpawner>();

        // Load the bee prefab from the Resources folder
        spawner.beePrefab = Resources.Load<GameObject>("BeePrefab");

        // Wait for one frame
        yield return null;

        // Count the number of Bee components in the scene
        int beeCount = GameObject.FindObjectsOfType<Bee>().Length;

        // Check if the number of spawned bees equals the desired number of bees
        Assert.AreEqual(spawner.numberOfBees, beeCount);
    }
}
