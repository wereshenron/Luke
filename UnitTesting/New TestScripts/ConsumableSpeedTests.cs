using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ConsumableSpeedTests
{
    [Test]
    public void SpeedBoostApplied()
    {
        // Create a player object and set its tag
        GameObject player = new GameObject("Player");
        player.tag = "Player";
        PlayerController playerController = player.AddComponent<PlayerController>();
        playerController.speed = 5f;

        // Create a ConsumableSpeed object and set its speed boost duration
        GameObject consumableSpeedObj = new GameObject("ConsumableSpeed");
        ConsumableSpeed consumableSpeed = consumableSpeedObj.AddComponent<ConsumableSpeed>();
        consumableSpeed.speedBoostDuration = 2f;

        // Simulate collision between the player and the ConsumableSpeed object
        consumableSpeed.OnTriggerEnter2D(player.GetComponent<Collider2D>());

        // Assert that the player's speed has increased after consuming the speed boost
        Assert.AreEqual(10f, playerController.speed);
    }
}
