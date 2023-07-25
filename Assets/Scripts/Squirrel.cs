/**

@class Squirrel
@brief This script is used to spawn bees
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for the behavior of individual squirrels.
/// </summary>
public class Squirrel : MonoBehaviour
{
    [SerializeField] private Transform luke; ///< Reference to Luke's transform
    [SerializeField] private float randomMoveSpeed = 3f; ///< Speed of the squirrel when moving randomly
    [SerializeField] private float fleeSpeed = 10f; ///< Speed of the squirrel when fleeing from Luke
    [SerializeField] private float fleeDistance = 5f; ///< Distance from Luke at which the squirrel starts fleeing

    private Vector3 randomDirection; ///< Random direction for the squirrel to move

    /// <summary>
    /// Initializes the script by finding Luke and setting a random direction.
    /// </summary>
    private void Start()
    {
        luke = GameObject.FindWithTag("Luke").transform;
        randomDirection = Random.insideUnitSphere;
    }

    /// <summary>
    /// Updates the squirrel's position based on its proximity to Luke.
    /// </summary>
    private void Update()
    {
        float distanceToLuke = Vector3.Distance(transform.position, luke.position);

        if (distanceToLuke < fleeDistance)
        {
            Vector3 fleeDirection = (transform.position - luke.position).normalized;
            transform.position += fleeDirection * fleeSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += randomDirection * randomMoveSpeed * Time.deltaTime;
        }
    }
}
