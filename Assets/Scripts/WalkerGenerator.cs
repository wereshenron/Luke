/**

@class WalkerGenerator
@brief This script is used to generate the map as well as place all enemies, objects, and the player
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class WalkerGenerator : MonoBehaviour
{

    /// <summary>
    /// The variable to keep track of the current state of a given tile in the grid when the map is created
    /// </summary>
    public enum Grid
    {
        FLOOR,
        WALL,
        EMPTY,
        EDGE_WALL,
        TREE,
        PLAYER,
        FOOD,
        ENEMY,
        BOOST,
        EXIT
    }



    /// <summary>
    /// The variable to keep track of the current grid
    /// </summary>
    public Grid[,] gridHandler;

    /// <summary>
    /// The list of walker objects that will create the map
    /// </summary>
    public List<WalkerObject> Walkers;

    /// <summary>
    /// The variable to keep track of the tilemap that will be used
    /// </summary>
    public Tilemap tileMap;

    /// <summary>
    /// The variable to define what will be placed as floor tiles
    /// </summary>
    public Tile Floor;

    /// <summary>
    /// The variable to define what will be placed as wall tiles
    /// </summary>
    public Tile Wall;

    /// <summary>
    /// The variable to define what will be placed as edge wall tiles
    /// </summary>
    public Tile EdgeWall;

    /// <summary>
    /// The variable to define what will be placed as tree tiles
    /// </summary>
    public Tile Tree;

    /// <summary>
    /// The variable to define the player object
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The variable to define the enemy object
    /// </summary>
    public GameObject enemy;

    /// <summary>
    /// The variable to define the apple object
    /// </summary>
    public GameObject apple;

    /// <summary>
    /// The variable to define the boost object
    /// </summary>
    public GameObject speed;

    /// <summary>
    /// The variable to define the exit object
    /// </summary>
    public GameObject exit;

    /// <summary>
    /// The variable to define the tiles that cannot be traveled via colliders
    /// </summary>
    public GameObject tileCollider;

    /// <summary>
    /// The variable to define the max item placement count
    /// </summary>
    public int maxItems;

    /// <summary>
    /// The variable to define the max speed boost placement count
    /// </summary>
    public int maxBoost;

    /// <summary>
    /// The variable to define the max enemies count
    /// </summary>
    public int maxEnemies;

    /// <summary>
    /// The variable to define map width
    /// </summary>
    public int MapWidth = 30;

    /// <summary>
    /// The variable to define map height
    /// </summary>
    public int MapHeight = 30;

    /// <summary>
    /// The variable to define the max number of walker objects that will be spawned
    /// </summary>
    public int MaximumWalkers = 10;

    /// <summary>
    /// The variable to define the tile count
    /// </summary>
    public int TileCount = default;

    /// <summary>
    /// The variable to define the map's fill percentage of floor tiles
    /// </summary>
    public float FillPercentage;

    /// <summary>
    /// The variable to define the wait time between tiles being placed
    /// </summary>
    public float WaitTime;

    private bool playerPresent = false; // Set the player as not present before script runs

    private int rand = 0; // Random integer variable

    
    private int currentNumberOfEnemies;
    

    void Start()
    {
        InitializeGrid();
        rand = Random.Range(1, 30);
        //Seperate variable to keep track of number of enemies to be decremented when enemy is destroyed
        currentNumberOfEnemies = maxEnemies;

    }
    
    //Decrement once an enemy is destroyed
    public void EnemyDestroyed()
    {
        // Decrement the number of enemies
        currentNumberOfEnemies--;

        // Check if the scene should be changed
        CheckForSceneChange();
    }

    //Scene change when all enemies are destroyed
    private void CheckForSceneChange()
    {
        // If there are no more enemies, load the next scene
        if (currentNumberOfEnemies <= 0)
        {
            // Change to the next scene
            
            placeItems(exit, 1, Grid.EXIT);
        }
    }


    /// <summary>
    /// Called to initialize the grid position and size
    /// </summary>
    public void InitializeGrid()
    {
        gridHandler = new Grid[MapWidth, MapHeight]; // Define the grid within the area defined 


        // Initially set every tile to empty
        for (int x = 0; x < gridHandler.GetLength(0); x++)
        {
            for (int y = 0; y < gridHandler.GetLength(1); y++)
            {
                gridHandler[x, y] = Grid.EMPTY;
            }
        }

        Walkers = new List<WalkerObject>(); // initialize walkers list

        Vector3Int TileCenter = new Vector3Int(gridHandler.GetLength(0) / 2, gridHandler.GetLength(1) / 2, 0); // define the center of a tile

        WalkerObject curWalker = new WalkerObject(new Vector2(TileCenter.x, TileCenter.y), GetDirection(), 0.5f); // create new walker object to create tiles
        gridHandler[TileCenter.x, TileCenter.y] = Grid.FLOOR; // Set the current tile as a floor 
        tileMap.SetTile(TileCenter, Floor); // Lay down the floor tile
        Walkers.Add(curWalker); // Add the current walker to the list of walker objects

        TileCount++; // Increase the tilecounter

        StartCoroutine(CreateFloors()); 
    }

    /// <summary>
    /// The method to choose the direction of the next walker
    /// </summary>
    public Vector2 GetDirection()
    {
        int choice = Mathf.FloorToInt(UnityEngine.Random.value * 3.99f); // Decide a direction randomly 


        // Switch statement to determine what the next direction will be
        switch (choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            case 3:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }

    /// <summary>
    /// The method to create all floor tiles as well as place player
    /// </summary>
    public IEnumerator CreateFloors()
    {
        // While the number of floor tiles over the number of tiles available is less than the fill percentage, fill in floor tiles
        while ((float)TileCount / (float)gridHandler.Length < FillPercentage) 
        {
            bool hasCreatedFloor = false; // Set this floor tile to not created initially

            // For every walker in walker list, walk through and fill in each tile with floor tiles
            foreach (WalkerObject curWalker in Walkers)
            {
                Vector3Int curPos = new Vector3Int((int)curWalker.Position.x, (int)curWalker.Position.y, 0); // Get the current position

                // If it isn't a floor yet, make it one and add it to the tilecount
                if (gridHandler[curPos.x, curPos.y] != Grid.FLOOR)
                {
                    tileMap.SetTile(curPos, Floor);
                    TileCount++;
                    gridHandler[curPos.x, curPos.y] = Grid.FLOOR;

                    // Use the random number generator to determine if the player will be placed in this position if the player isn't already present    
                    if ((rand % 23 == 0) && playerPresent == false)
                    {
                        playerPresent = true;
                        Vector3Int playerPos = new Vector3Int((int)curWalker.Position.x, (int)curWalker.Position.y, 1);
                        player.transform.position = playerPos;
                        gridHandler[curPos.x, curPos.y] = Grid.PLAYER;



                    }
                    hasCreatedFloor = true; // Mark this tile as a floor tile 
                }
            }

            //Walker Methods
            ChanceToRemove();
            ChanceToRedirect();
            ChanceToCreate();
            UpdatePosition();

            if (hasCreatedFloor)
            {
                yield return new WaitForSeconds(WaitTime);
            }
        }

        StartCoroutine(CreateWallsAndTrees());
    }

    // Walker method to find the chance that this current walker will be removed
    void ChanceToRemove()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].ChanceToChange && Walkers.Count > 1)
            {
                Walkers.RemoveAt(i);
                break;
            }
        }
    }

// Walker method to find the chance that this current walker will be redirected
    void ChanceToRedirect()
    {
        for (int i = 0; i < Walkers.Count; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].ChanceToChange)
            {
                WalkerObject curWalker = Walkers[i];
                curWalker.Direction = GetDirection();
                Walkers[i] = curWalker;
            }
        }
    }

// Walker method to find the chance that this current walker will be created
    void ChanceToCreate()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].ChanceToChange && Walkers.Count < MaximumWalkers)
            {
                Vector2 newDirection = GetDirection();
                Vector2 newPosition = Walkers[i].Position;

                WalkerObject newWalker = new WalkerObject(newPosition, newDirection, 0.5f);
                Walkers.Add(newWalker);
            }
        }
    }

    // Walker method to update the given walker's position
    void UpdatePosition()
    {
        for (int i = 0; i < Walkers.Count; i++)
        {
            WalkerObject FoundWalker = Walkers[i];
            FoundWalker.Position += FoundWalker.Direction;
            FoundWalker.Position.x = Mathf.Clamp(FoundWalker.Position.x, 1, gridHandler.GetLength(0) - 2);
            FoundWalker.Position.y = Mathf.Clamp(FoundWalker.Position.y, 1, gridHandler.GetLength(1) - 2);
            Walkers[i] = FoundWalker;
        }
    }


    /// <summary>
    /// The method to create all wall and tree tiles
    /// </summary>
    IEnumerator CreateWallsAndTrees()
    {
        // For every floor tile, check if there is an empty space surrounding it. If there is, make that tile a wall. 
        for (int x = 0; x < gridHandler.GetLength(0); x++)
        {
            for (int y = 0; y < gridHandler.GetLength(1); y++)
            {
                if (gridHandler[x, y] == Grid.FLOOR)
                {
                    bool hasCreatedWall = false; // Check if a wall has been created here

                    if (x + 1 < gridHandler.GetLength(0) && gridHandler[x + 1, y] == Grid.EMPTY)
                    {
                        Tile wallTile = x + 1 == gridHandler.GetLength(0) - 1 ? EdgeWall : Wall;
                        Vector3Int tilePosition = new Vector3Int(x + 1, y, 0);
                        tileMap.SetTile(tilePosition, wallTile);
                        gridHandler[x + 1, y] = wallTile == EdgeWall ? Grid.EDGE_WALL : Grid.WALL;
                        hasCreatedWall = true;
                        gridHandler[x +1, y] = Grid.WALL;
                    }
                    if (x - 1 >= 0 && gridHandler[x - 1, y] == Grid.EMPTY)
                    {
                        Tile wallTile = x - 1 == 0 ? EdgeWall : Wall;
                        tileMap.SetTile(new Vector3Int(x - 1, y, 0), wallTile);
                        Instantiate(tileCollider, new Vector3Int(x - 1, y, 0), Quaternion.identity);
                        gridHandler[x - 1, y] = wallTile == EdgeWall ? Grid.EDGE_WALL : Grid.WALL;
                        hasCreatedWall = true;
                        gridHandler[x -1, y] = Grid.WALL;
                    }
                    if (y + 1 < gridHandler.GetLength(1) && gridHandler[x, y + 1] == Grid.EMPTY)
                    {
                        Tile wallTile = y + 1 == gridHandler.GetLength(1) - 1 ? EdgeWall : Wall;
                        tileMap.SetTile(new Vector3Int(x, y + 1, 0), wallTile);
                        Instantiate(tileCollider, new Vector3Int(x, y + 1, 0), Quaternion.identity);
                        gridHandler[x, y + 1] = wallTile == EdgeWall ? Grid.EDGE_WALL : Grid.WALL;
                        hasCreatedWall = true;
                        gridHandler[x, y+1] = Grid.WALL;
                    }
                    if (y - 1 >= 0 && gridHandler[x, y - 1] == Grid.EMPTY)
                    {
                        Tile wallTile = y - 1 == 0 ? EdgeWall : Wall;
                        tileMap.SetTile(new Vector3Int(x, y - 1, 0), wallTile);
                        Instantiate(tileCollider, new Vector3Int(x, y - 1, 0), Quaternion.identity);
                        gridHandler[x, y - 1] = wallTile == EdgeWall ? Grid.EDGE_WALL : Grid.WALL;
                        hasCreatedWall = true;
                        gridHandler[x, y-1] = Grid.WALL;
                    }

                    if (hasCreatedWall)
                    {
                        yield return new WaitForSeconds(WaitTime);
                    }
                }

                // Check if the cell is not EdgeWall or Floor
                else if (gridHandler[x, y] != Grid.EDGE_WALL && gridHandler[x, y] != Grid.FLOOR) 
                {
                    tileMap.SetTile(new Vector3Int(x, y, 0), Tree);
                    Instantiate(tileCollider, new Vector3Int(x, y, 0), Quaternion.identity);
                    gridHandler[x, y] = Grid.WALL;
                }
            }
        }
        placeItems(enemy, maxEnemies, Grid.ENEMY); // After map has been built, run a function to place enemies on the map
        placeItems(apple, maxItems, Grid.FOOD); // After map has been built, run a function to place apples on the map.
        placeItems(speed, maxBoost, Grid.BOOST);// After map has been built, run a function to place speed  on the map.

    }

    // placeItems()
    // Run through the entire map grid tile by tile and check if there is an enemy, player, or food already 
    // In the tile. This function also checks whether the current tile is "walkable" (floor/wall) and will
    // Place an enemy randomly if all of there is nothing else populating the tile, and the tile is walkable. 

    // Takes parameters-
    // Item- what type of gameobject we want to place 

    /// <summary>
    /// Run through the entire map grid tile by tile and check if there is an enemy, player, or food already in the tile. This function also checks whether the current tile is "walkable" (floor/wall) and will place an //////// enemy randomly if all of there is nothing else populating the tile, and the tile is walkable. 
    /// </summary>
    /// <param name="item">The object that this hitbox collided with.</param>
    /// <param name="maxItems">The maximum number of items of this type to place</param>
    /// <param name="gridType">The type of tile placed in a given grid location</param>

    public void placeItems(GameObject item, int maxItems, Grid gridType)
    {
        int itemCount = 0; // Iterator variable to keep track of no. enemies created thus far
        while (itemCount < maxItems)
        {
            for (int x = 0; x < gridHandler.GetLength(0); x++) // For every tile on the x axis within the map
            {
                for (int y = 0; y < gridHandler.GetLength(1); y++) // For every tile on the y axis within the map
                {
                    int randomNumber = Random.Range(0, 1001); // Generate a random int from 0-1001

                    // Conditional explained in method description
                    if (gridHandler[x, y] != Grid.PLAYER && gridHandler[x, y] == Grid.FLOOR && (gridHandler[x, y] != Grid.WALL || gridHandler[x, y] != Grid.EDGE_WALL))
                    {
                        // Conditional statement to randomize placement - if random # generated from 1-1001 is 1000 then place object. Chance of object spawning in is 1 in 1000.
                        if (itemCount < maxItems && randomNumber == 1000)
                        {
                            Instantiate(item, new Vector3Int(x, y, 0), Quaternion.identity); // Place enemy object
                            gridHandler[x, y] = gridType; // Declare this tile as inhabited by enemy 
                            itemCount++; // Iterate itemCount to prevent infinite while loop
                        }
                    }

                }
            }
        }

    }





}



