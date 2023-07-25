using UnityEngine;
using NUnit.Framework;

public class RayShooterTests
{
    [Test]
    public void TestProjectileLaunchDirection()
    {
        // Arrange
        var gameObject = new GameObject();
        var rayShooter = gameObject.AddComponent<RayShooter>();

        // Act
        rayShooter.prefabToLaunch = new GameObject();
        rayShooter.launchForce = 1f;
        rayShooter.verticalLaunchForce = 1f;

        // Simulate launching projectile to the right
        rayShooter.Update();
        Input.GetKeyDown(KeyCode.T);

        // Assert
        Assert.AreEqual(RayShooter.Direction.RIGHT, rayShooter.currentDirection);

        // Simulate launching projectile to the left
        rayShooter.Update();
        Input.GetKeyDown(KeyCode.T);

        // Assert
        Assert.AreEqual(RayShooter.Direction.LEFT, rayShooter.currentDirection);

        // Simulate launching projectile upwards
        rayShooter.Update();
        Input.GetKeyDown(KeyCode.T);

        // Assert
        Assert.AreEqual(RayShooter.Direction.UP, rayShooter.currentDirection);

        // Simulate launching projectile downwards
        rayShooter.Update();
        Input.GetKeyDown(KeyCode.T);

        // Assert
        Assert.AreEqual(RayShooter.Direction.DOWN, rayShooter.currentDirection);
    }
}
