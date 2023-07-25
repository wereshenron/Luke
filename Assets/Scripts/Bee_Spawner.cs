/**

@class BeeSpawner
@brief This script is used to spawn bees
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for spawning bees and managing their group behavior.
/// </summary>
public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject beePrefab; ///< Reference to the bee prefab
    [SerializeField] private int numberOfBees = 5; ///< Number of bees to spawn
    private List<GameObject> bees; ///< List to store the spawned bees

    /// <summary>
    /// Initializes the script by spawning bees.
    /// </summary>
    private void Start()
    {
        bees = new List<GameObject>();
        for (int i = 0; i < numberOfBees; i++)
        {
            GameObject bee = Instantiate(beePrefab, transform.position + Random.insideUnitSphere * 5f, Quaternion.identity);
            bees.Add(bee);
        }
    }

    /// <summary>
    /// Starts chasing Luke for all bees.
    /// </summary>
    public void StartChasingLuke()
    {
        foreach (GameObject bee in bees)
        {
            bee.GetComponent<Bee>().StartChasingLuke();
        }
    }
}
