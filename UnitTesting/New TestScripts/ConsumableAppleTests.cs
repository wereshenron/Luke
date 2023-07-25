using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ConsumableAppleTests
{
    [Test]
    public void AppleHealsPlayer()
    {
        // Create a player object and set its health and max health
        GameObject player = new GameObject("Player");
        PlayerHealth playerHealth = player.AddComponent<PlayerHealth>();
        playerHealth.Health = 50;
        playerHealth.maxHealth = 100;
        player.tag = "Player";

        // Create an apple object and set its heal amount
        GameObject apple = new GameObject("Apple");
        ConsumableApple consumableApple = apple.AddComponent<ConsumableApple>();
        consumableApple.healAmount = 20;

        // Simulate collision between the player and the apple
        consumableApple.OnTriggerEnter2D(player.GetComponent<Collider2D>());

        // Assert that the player's health is increased after consuming the apple
        Assert.AreEqual(70, playerHealth.Health);
    }
}
