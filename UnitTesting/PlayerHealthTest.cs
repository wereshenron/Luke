using NUnit.Framework;
using UnityEngine;

public class PlayerHealthTests
{
    [Test]
    public void PlayerHealth_HealthVariable_IsInitializedToThree()
    {
        // Arrange
        var player = new GameObject().AddComponent<PlayerHealth>();

        // Assert
        Assert.AreEqual(3f, player._health);
    }

    [Test]
    public void PlayerHealth_SetHealthMethod_SetsHealthVariable()
    {
        // Arrange
        var player = new GameObject().AddComponent<PlayerHealth>();

        // Act
        player.Health = 2f;

        // Assert
        Assert.AreEqual(2f, player._health);
    }

    [Test]
    public void PlayerHealth_SetHealthMethod_DestroysGameObjectIfHealthIsZero()
    {
        // Arrange
        var player = new GameObject().AddComponent<PlayerHealth>();
        player._health = 0f;

        // Act
        player.Health = 0f;

        // Assert
        Assert.IsTrue(player.gameObject == null);
    }
}

///The first test checks if the _health variable is initialized to 3 when a new PlayerHealth object is created.
///The second test checks if the Health property properly sets the _health variable when called.
///The third test checks if the Health property destroys the gameObject if _health is set to 0.