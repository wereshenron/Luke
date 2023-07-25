using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SquirrelTests
{
    [UnityTest]
    public IEnumerator SquirrelSpawnerSpawnsSquirrels()
    {
        GameObject spawnerObject = new GameObject();
        SquirrelSpawner spawner = spawnerObject.AddComponent<SquirrelSpawner>();
        spawner.squirrelPrefab = Resources.Load<GameObject>("SquirrelPrefab");

        yield return null;

        int squirrelCount = GameObject.FindObjectsOfType<Squirrel>().Length;
        Assert.AreEqual(spawner.numberOfSquirrels, squirrelCount);
    }
}
