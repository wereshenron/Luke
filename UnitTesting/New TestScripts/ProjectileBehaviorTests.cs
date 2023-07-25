using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ProjectileBehaviorTests
{
    [Test]
    public void ShootProjectilesSpawnsProjectiles()
    {
        // Create a ProjectileBehavior object
        GameObject projectileObj = new GameObject("ProjectileBehavior");
        ProjectileBehavior projectileBehavior = projectileObj.AddComponent<ProjectileBehavior>();

        // Create a dummy player object
        GameObject playerObj = new GameObject("Player");
        playerObj.tag = "Player";

        // Create a dummy projectile prefab
        GameObject dummyProjectilePrefab = new GameObject("DummyProjectilePrefab");
        projectileBehavior.projectilePrefab = dummyProjectilePrefab;

        // Call ShootProjectiles method
        projectileBehavior.ShootProjectiles();

        // Check if the projectiles were instantiated
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Untagged");
        Assert.AreEqual(4, projectiles.Length);
    }
}
