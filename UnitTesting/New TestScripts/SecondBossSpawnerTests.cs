using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class SecondBossSpawnerTests
{
    [Test]
    public void SpawnerAssignsUniqueSpawnPoints()
    {
        GameObject spawnerObj = new GameObject("SecondBossSpawner");
        SecondBossSpawner spawner = spawnerObj.AddComponent<SecondBossSpawner>();

        spawner.playerObject = new GameObject("Player");
        spawner.bossObject = new GameObject("Boss");
        spawner.secondaryOne = new GameObject("SecondaryOne");
        spawner.secondaryTwo = new GameObject("SecondaryTwo");
        spawner.secondaryThree = new GameObject("SecondaryThree");
        spawner.secondaryFour = new GameObject("SecondaryFour");

        spawner.Start();

        List<Vector2> positions = new List<Vector2>
        {
            spawner.playerObject.transform.position,
            spawner.bossObject.transform.position,
            spawner.secondaryOne.transform.position,
            spawner.secondaryTwo.transform.position,
            spawner.secondaryThree.transform.position,
            spawner.secondaryFour.transform.position
        };

        Assert.AreEqual(6, positions.Count);
        Assert.AreEqual(6, new HashSet<Vector2>(positions).Count);
    }
}
