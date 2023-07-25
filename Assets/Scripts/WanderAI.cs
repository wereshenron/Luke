/**

@class WanderAI
@brief This script is attached to all enemies to control their movement
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{

    /// <summary>
    /// Movement speed of the enemy
    /// </summary>
    public float speed = 6f; 

    /// <summary>
    /// Interval at which the enemy checks if it has moved far enough
    /// </summary>
    public float checkInterval; 

    /// <summary>
    /// Minimum distance the enemy should move
    /// </summary>
    public float tileDistance; 
    private Vector2 wayPoint; // The destination point for the enemy's movement
    private Vector2 previousPosition; // The enemy's previous position for distance comparison
    private Animator animator;


    void Start()
    {
        previousPosition = transform.position; // Store the initial position
        SetNewDestination(); // Set an initial destination
        StartCoroutine(CheckIfMoved()); // Start checking if the enemy has moved far enough
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Move the enemy towards the waypoint
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        // Determine the direction of movement
        float direction = 0.5f; // 0.5 = idle, 0 = left, 1 = right
        if (transform.position.x < previousPosition.x)
        {
            direction = 0;
        }
        else if (transform.position.x > previousPosition.x)
        {
            direction = 1;
        }

        // Update the animator controller with the direction value
        animator.SetFloat("Direction", direction);

        // Update the previous position for the next frame
        previousPosition = transform.position;
    }


    void SetNewDestination()
    {
        // Find a new random direction and set the waypoint
        wayPoint = FindRandomDirection();
    }

    IEnumerator CheckIfMoved()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval); // Wait for the checkInterval

            // Calculate the distance moved since the previous position
            float distanceMoved = Vector2.Distance(transform.position, previousPosition);

            // If the distance moved is less than tileDistance, set a new destination
            if (distanceMoved < tileDistance)
            {
                SetNewDestination();
            }

            // Update the previous position for the next check
            previousPosition = transform.position;
        }
    }

    Vector2 FindRandomDirection()
    {
        // Define possible movement directions
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right, Vector2.up + Vector2.right, Vector2.up + Vector2.left, Vector2.down + Vector2.right, Vector2.down + Vector2.left };

        // Select a random direction index
        int randomDirIndex = Random.Range(0, directions.Length);

        // Normalize the selected direction
        Vector2 normalizedDirection = directions[randomDirIndex].normalized;

        // Calculate the new waypoint by adding the direction multiplied by a large number to the current position
        Vector2 newWayPoint = (Vector2)transform.position + normalizedDirection * 50;

        return newWayPoint;
    }
}
