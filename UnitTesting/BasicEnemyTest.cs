using NUnit.Framework;
using UnityEngine;

public class BasicEnemyTest
{
    [Test]
    public void TestEnemyHealth()
    {
        // Arrange
        GameObject enemyObject = new GameObject();
        BasicEnemy enemy = enemyObject.AddComponent<BasicEnemy>();
        float initialHealth = enemy._health;

        // Act
        enemy.Health = initialHealth - 1f;
        float newHealth = enemy.Health;

        // Assert
        Assert.AreEqual(newHealth, initialHealth - 1f);
    }
}
