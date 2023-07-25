/**

@class Mailman_Spawner
@brief This script is used to spawn mailmen
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for spawning mailmen.
/// </summary>
public class Mailman_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject mailmanPrefab; ///< Reference to the mailman prefab
    [SerializeField] private int numberOfMailmen = 5; ///< Number of mailmen to spawn
    private List<GameObject> mailmen; ///< List to store the spawned mailmen

    /// <summary>
    /// Initializes the script by spawning mailmen.
    /// </summary>
    private void Start()
    {
        mailmen = new List<GameObject>();

        for (int i = 0; i < numberOfMailmen; i++)
        {
            GameObject mailman = Instantiate(mailmanPrefab, transform.position + Random.insideUnitSphere * 5f, Quaternion.identity);
            mailmen.Add(mailman);
        }
    }
}
