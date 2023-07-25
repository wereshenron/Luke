using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MailmanTests
{
    [UnityTest]
    public IEnumerator MailmanSpawnerSpawnsMailmen()
    {
        GameObject spawnerObject = new GameObject();
        MailmanSpawner spawner = spawnerObject.AddComponent<MailmanSpawner>();
        spawner.mailmanPrefab = Resources.Load<GameObject>("MailmanPrefab");

        yield return null;

        int mailmanCount = GameObject.FindObjectsOfType<Mailman>().Length;
        Assert.AreEqual(spawner.numberOfMailmen, mailmanCount);
    }
}
