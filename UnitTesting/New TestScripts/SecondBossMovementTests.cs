using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class SecondBossMovementTests
{
    [Test]
    public void ResetSpeedResetsSpeedMultiplier()
    {
        // Create a SecondBossMovement object
        GameObject secondBossObj = new GameObject("SecondBossMovement");
        SecondBossMovement secondBossMovement = secondBossObj.AddComponent<SecondBossMovement>();

        // Create a dummy player object
        GameObject playerObj = new GameObject("Player");
        secondBossMovement.playerTransform = playerObj.transform;

        // Set the speedMultiplier to 3f
        secondBossMovement.speedMultiplier = 3f;

        // Call ResetSpeed method
        secondBossMovement.ResetSpeed();

        // Check if the speedMultiplier is reset to 1f
        Assert.AreEqual(1f, secondBossMovement.speedMultiplier);
    }
}
