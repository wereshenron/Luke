/**

@class Squirrel_Spawner
@brief This script is used to spawn bees
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for spawning squirrels.
/// </summary>
public class Squirrel_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject squirrelPrefab; ///< Reference to the squirrel prefab
    [SerializeField] private int numberOfSquirrels = 15; ///< Number of squirrels to spawn
    private List<GameObject> squirrels; ///< List to store the spawned squirrels

    /// <summary>
    /// Initializes the script by spawning squirrels.
    /// </summary>
    private void Start()
    {
        squirrels = new List<GameObject>();

        for (int i = 0; i < numberOfSquirrels; i++)
        {
            GameObject squirrel = Instantiate(squirrelPrefab, transform.position + Random.insideUnitSphere * 5f, Quaternion.identity);
            squirrels.Add(squirrel);
        }
    }
}
