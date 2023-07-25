using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class HealthBarTests
{
    [Test]
    public void HealthBarPositionUpdate()
    {
        // Create a player object and set its health and max health
        GameObject player = new GameObject("Player");
        PlayerHealth playerHealth = player.AddComponent<PlayerHealth>();
        playerHealth.Health = 50;
        playerHealth.maxHealth = 100;

        // Create a health bar object
        GameObject healthBarObj = new GameObject("HealthBar");
        HealthBar healthBar = healthBarObj.AddComponent<HealthBar>();
        healthBar.player = player;

        // Call the LateUpdate() method to update the health bar's position
        healthBar.LateUpdate();

        // Check if the health bar's position is correctly updated
        Vector3 expectedPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.95f, 0f));
        Assert.AreEqual(expectedPosition, healthBarObj.transform.position);
    }
}
