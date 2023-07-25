using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ConditionalItemPlacerTests
{
    [Test]
    public void ItemPlacedIfBossDoesNotExist()
    {
        // Arrange
        var itemPlacer = new GameObject().AddComponent<ItemPlacer>();
        var conditionalItemPlacer = new GameObject().AddComponent<ConditionalItemPlacer>();
        conditionalItemPlacer.objectName = "NonExistentBoss";
        conditionalItemPlacer.itemPlacer = itemPlacer;

        // Act
        conditionalItemPlacer.Start();

        // Assert
        Assert.IsTrue(itemPlacer.ItemPlaced);
    }

    [Test]
    public void ItemNotPlacedIfBossExists()
    {
        // Arrange
        var itemPlacer = new GameObject().AddComponent<ItemPlacer>();
        var conditionalItemPlacer = new GameObject().AddComponent<ConditionalItemPlacer>();
        conditionalItemPlacer.objectName = "ExistingBoss";
        conditionalItemPlacer.itemPlacer = itemPlacer;
        GameObject boss = new GameObject("ExistingBoss");

        // Act
        conditionalItemPlacer.Start();

        // Assert
        Assert.IsFalse(itemPlacer.ItemPlaced);
    }

    [Test]
    public void GameObjectExistsReturnsTrueIfObjectExists()
    {
        // Arrange
        GameObject obj = new GameObject("ExistingObject");
        var conditionalItemPlacer = new ConditionalItemPlacer();

        // Act
        bool exists = conditionalItemPlacer.DoesGameObjectExist("ExistingObject");

        // Assert
        Assert.IsTrue(exists);
    }

    [Test]
    public void GameObjectExistsReturnsFalseIfObjectDoesNotExist()
    {
        // Arrange
        var conditionalItemPlacer = new ConditionalItemPlacer();

        // Act
        bool exists = conditionalItemPlacer.DoesGameObjectExist("NonExistentObject");

        // Assert
        Assert.IsFalse(exists);
    }
}
