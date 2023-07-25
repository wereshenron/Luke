/**

@class SecondBossSpawner
@brief This script is used to place the second boss on the map
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossSpawner : MonoBehaviour
{

    /// <summary>
    /// Public variable for the player object
    /// </summary>
    public GameObject playerObject;

    /// <summary>
    /// public variable for the player object
    /// </summary>

    /// <summary>
    /// public variable for the boss object
    /// </summary>
    public GameObject bossObject;
    
    /// <summary>
    /// public variable for the first side enemy
    /// </summary>
    public GameObject secondaryOne;

    /// <summary>
    /// public variable for the second side enemy
    /// </summary>
    public GameObject secondaryTwo;

    /// <summary>
    /// public variable for the third side enemy
    /// </summary>
    public GameObject secondaryThree;

    /// <summary>
    /// public variable for the fourth side enemy
    /// </summary>
    public GameObject secondaryFour;

    // Six private variables for spawn points in the game world, each represented as a Vector2
    private Vector2 firstSpawn = new Vector2(10f, 10f);
    bool firstSpawnTaken = false;
    private Vector2 secondSpawn = new Vector2(8f, 12f);
    bool secondSpawnTaken = false;
    private Vector2 thirdSpawn = new Vector2(8f, 12f);
    bool thirdSpawnTaken = false;
    private Vector2 fourthSpawn = new Vector2(15f, 5f);
    bool fourthSpawnTaken = false;
    private Vector2 fifthSpawn = new Vector2(2f, 2f);
    bool fifthSpawnTaken = false;
    private Vector2 sixthSpawn = new Vector2(5f, 15f);
    bool sixthSpawnTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        // Randomly choose a spawn point for the player and boss and secondary enemies
        int playerSpawn = Random.Range(1, 7);
        int bossSpawn = Random.Range(1, 7);
        int secondaryOneSpawn = Random.Range(1,7);
        int secondaryTwoSpawn = Random.Range(1,7);
        int secondaryThreeSpawn = Random.Range(1,7);
        int secondaryFourSpawn = Random.Range(1,7);

        // Keep assigning a new spawn until they aren't the same
        while (bossSpawn == playerSpawn)
        {
            bossSpawn = Random.Range(1, 7);
        }

        while (secondaryOneSpawn == playerSpawn || secondaryOneSpawn == bossSpawn)
        {
            secondaryOneSpawn = Random.Range(1,7);
        }

        while (secondaryTwoSpawn == playerSpawn || secondaryTwoSpawn == bossSpawn || secondaryTwoSpawn == secondaryOneSpawn)
        {
            secondaryTwoSpawn = Random.Range(1,7);
        }

        while (secondaryThreeSpawn == playerSpawn || secondaryThreeSpawn == bossSpawn || secondaryThreeSpawn == secondaryOneSpawn || secondaryThreeSpawn == secondaryTwoSpawn)
        {
            secondaryThreeSpawn = Random.Range(1,7);
        }

        while (secondaryFourSpawn == playerSpawn || secondaryFourSpawn == bossSpawn || secondaryFourSpawn == secondaryOneSpawn || secondaryFourSpawn == secondaryTwoSpawn || secondaryFourSpawn == secondaryThreeSpawn)
        {
            secondaryFourSpawn = Random.Range(1,7);
        }

        // Set the player's position to the chosen spawn point and mark it as taken
        if(playerSpawn == 1)
        {
            playerObject.transform.position = firstSpawn;
            firstSpawnTaken = true;
        }
        else if (playerSpawn == 2)
        {
            playerObject.transform.position = secondSpawn;
            secondSpawnTaken = true;
        }
        else if (playerSpawn == 3)
        {
            playerObject.transform.position = thirdSpawn;
            thirdSpawnTaken = true;
        }
        else if (playerSpawn == 4)
        {
            playerObject.transform.position = fourthSpawn;
            fourthSpawnTaken = true;
        }
        else if (playerSpawn == 5)
        {
            playerObject.transform.position = fifthSpawn;
            fifthSpawnTaken = true;
        }
        else if (playerSpawn == 6)
        {
            playerObject.transform.position = sixthSpawn;
            sixthSpawnTaken = true;
        }

         // Set the bosses spawn if the spawn is available
        if(bossSpawn == 1 && !firstSpawnTaken)
        {
            bossObject.transform.position = firstSpawn;
            firstSpawnTaken = true;
        }
        else if (bossSpawn == 2 && !secondSpawnTaken)
        {
            bossObject.transform.position = secondSpawn;
            secondSpawnTaken = true;
        }
        else if (bossSpawn == 3 && !thirdSpawnTaken)
        {
            bossObject.transform.position = thirdSpawn;
            thirdSpawnTaken = true;
        }
        else if (bossSpawn == 4 && !fourthSpawnTaken)
        {
            bossObject.transform.position = fourthSpawn;
            fourthSpawnTaken = true;
        }
        else if (bossSpawn == 5 && !fifthSpawnTaken)
        {
            bossObject.transform.position = fifthSpawn;
            fifthSpawnTaken = true;
        }
        else if (bossSpawn == 6 && !sixthSpawnTaken)
        {
            bossObject.transform.position = sixthSpawn;
            sixthSpawnTaken = true;
        }

    }

    

}
