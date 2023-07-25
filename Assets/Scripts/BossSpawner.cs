/**

@class BossSpawner
@brief This script is used to spawn the first boss in the game.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    /// <summary>
    /// Reference to the player object to spawn
    /// </summary>
    public GameObject playerObject;

    // Eight possible spawn positions for the player object
    private Vector2 spawn1 = new Vector2(19.04f, 16.26f);
    private Vector2 spawn2 = new Vector2(38.67f, 17.82f);
    private Vector2 spawn3 = new Vector2(37.77f, 2.21f);
    private Vector2 spawn4 = new Vector2(20.78f, 2.03f);
    private Vector2 spawn5 = new Vector2(14.72f, 10.43f);
    private Vector2 spawn6 = new Vector2(40.65f, 10.43f);
    private Vector2 spawn7 = new Vector2(30.87f, 1.49f);
    private Vector2 spawn8 = new Vector2(27.03f, 18f);

    // Start is called before the first frame update
    void Start()
    {
        // Choose a random spawn point index between 1 and 8
        int spawnPoint = Random.Range(1, 9);

        // Use a switch statement to move the player object to the chosen spawn point
        switch (spawnPoint)
        {
            case 1:
                playerObject.transform.position = spawn1;
                break;
            case 2:
                playerObject.transform.position = spawn2;
                break;
            case 3:
                playerObject.transform.position = spawn3;
                break;
            case 4:
                playerObject.transform.position = spawn4;
                break;
            case 5:
                playerObject.transform.position = spawn5;
                break;
            case 6:
                playerObject.transform.position = spawn6;
                break;
            case 7:
                playerObject.transform.position = spawn7;
                break;
            case 8:
                playerObject.transform.position = spawn8;
                break;
            default:
                // If the spawn point index is invalid, log an error message
                Debug.LogError("Invalid spawn index: " + spawnPoint);
                break;
        }
    }
}

