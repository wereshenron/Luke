/**

@class Bee
@brief This script is used to control bee behavior 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for the behavior of individual bees.
/// </summary>
public class Bee : MonoBehaviour
{
    [SerializeField] private float speed = 5f; ///< Speed of the bee when chasing Luke
    [SerializeField] private float randomMoveSpeed = 3f; ///< Speed of the bee when moving randomly
    private Transform luke; ///< Reference to Luke's transform
    private Vector3 randomDirection; ///< Random direction for the bee to move
    private bool isChasingLuke; ///< Flag to determine if the bee is chasing Luke

    /// <summary>
    /// Initializes the script by finding Luke and setting a random direction.
    /// </summary>
    private void Start()
    {
        luke = GameObject.FindWithTag("Luke").transform;
        randomDirection = Random.insideUnitSphere;
    }

    /// <summary>
    /// Updates the bee's position based on its current state.
    /// </summary>
    private void Update()
    {
        if (isChasingLuke)
        {
            transform.position = Vector3.MoveTowards(transform.position, luke.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position += randomDirection * randomMoveSpeed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Starts chasing Luke.
    /// </summary>
    public void StartChasingLuke()
    {
        isChasingLuke = true;
    }

    /// <summary>
    /// Handles collision with other objects.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Luke"))
        {
            StartChasingLuke();
        }
    }
}
