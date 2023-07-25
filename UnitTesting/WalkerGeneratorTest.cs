using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Tilemaps;

public class WalkerGeneratorTests
{
    [UnityTest]
    public IEnumerator WalkerGenerator_MapGeneratedCorrectly()
    {
        // Arrange
        GameObject walkerGeneratorObject = new GameObject("WalkerGenerator");
        WalkerGenerator walkerGenerator = walkerGeneratorObject.AddComponent<WalkerGenerator>();
        Tilemap tileMap = walkerGeneratorObject.AddComponent<Tilemap>();
        TilemapCollider2D tilemapCollider = walkerGeneratorObject.AddComponent<TilemapCollider2D>();

        // Set the tilemaps for the walker generator
        walkerGenerator.tileMap = tileMap;
        walkerGenerator.tileCollider = tilemapCollider.gameObject;

        // Set the map width and height to 10
        walkerGenerator.MapWidth = 10;
        walkerGenerator.MapHeight = 10;

        // Set the maximum number of walkers to 1
        walkerGenerator.MaximumWalkers = 1;

        // Set the fill percentage to 0.5f
        walkerGenerator.FillPercentage = 0.5f;

        // Set the wait time to 0.1f
        walkerGenerator.WaitTime = 0.1f;

        // Set the maximum number of enemies and items to 5
        walkerGenerator.maxEnemies = 5;
        walkerGenerator.maxItems = 5;

        // Act
        walkerGenerator.InitializeGrid();
        yield return new WaitForSeconds(2f);

        // Assert

        // Check if there is only one player object
        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        Assert.AreEqual(1, playerCount);

        // Check if the number of enemy objects is less than or equal to the maximum number of enemies
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Assert.LessOrEqual(enemyCount, walkerGenerator.maxEnemies);

        // Check if the number of apple objects is less than or equal to the maximum number of items
        int appleCount = GameObject.FindGameObjectsWithTag("Apple").Length;
        Assert.LessOrEqual(appleCount, walkerGenerator.maxItems);

        // Check if the number of floor tiles is greater than 0
        int floorCount = GameObject.FindGameObjectsWithTag("Floor").Length;
        Assert.Greater(floorCount, 0);

        // Check if the number of wall tiles is greater than 0
        int wallCount = GameObject.FindGameObjectsWithTag("Wall").Length;
        Assert.Greater(wallCount, 0);

        // Check if the number of edge wall tiles is greater than 0
        int edgeWallCount = GameObject.FindGameObjectsWithTag("EdgeWall").Length;
        Assert.Greater(edgeWallCount, 0);
    }
}
