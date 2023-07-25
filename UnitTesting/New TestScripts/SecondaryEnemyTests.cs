using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class SecondaryEnemyTests
{
    [Test]
    public void ShootAtPlayerCreatesBullet()
    {
        GameObject secondaryEnemyObj = new GameObject("SecondaryEnemy");
        SecondaryEnemy secondaryEnemy = secondaryEnemyObj.AddComponent<SecondaryEnemy>();

        secondaryEnemy.player = new GameObject("Player").transform;

        GameObject dummyBulletPrefab = new GameObject("DummyBulletPrefab");
        secondaryEnemy.bulletPrefab = dummyBulletPrefab;

        secondaryEnemy.ShootAtPlayer();

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Untagged");
        Assert.AreEqual(1, bullets.Length);
    }
}
