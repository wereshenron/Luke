using NUnit.Framework;
using UnityEngine;

public class ConsumableItemTest
{
    [Test]
    public void TestConsumableItemCollision()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        playerObject.tag = "Player";
        GameObject consumableItemObject = new GameObject();
        ConsumableItem consumableItem = consumableItemObject.AddComponent<ConsumableItem>();

        // Act
        BoxCollider2D playerCollider = playerObject.AddComponent<BoxCollider2D>();
        playerCollider.size = Vector2.one;
        playerCollider.offset = Vector2.zero;

        BoxCollider2D consumableItemCollider = consumableItemObject.AddComponent<BoxCollider2D>();
        consumableItemCollider.size = Vector2.one;
        consumableItemCollider.offset = Vector2.zero;

        consumableItem.OnTriggerEnter2D(playerCollider);

        // Assert
        Assert.IsTrue(consumableItemObject == null);
    }
}
