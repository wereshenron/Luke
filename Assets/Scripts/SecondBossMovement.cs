/**

@class SecondBossMovement
@brief This script is used for the movement of the second boss 
*/
using UnityEngine;

public class SecondBossMovement : MonoBehaviour
{

    /// <summary>
    /// The base movement speed of the enemy
    /// </summary>
    public float movementSpeed = 5f; 

    /// <summary>
    /// The speed at which the enemy turns to face the player
    /// </summary>
    public float turnSpeed = 10f; 

    /// <summary>
    /// A reference to the player's transform
    /// </summary>
    public Transform playerTransform; 

    /// <summary>
    /// A prefab for the explosion effect
    /// </summary>
    public GameObject explosionEffect; 

    private float speedMultiplier = 1f; // A multiplier for the movement speed
    private float nextSpeedBoostTime = 10f; // The time at which the next speed boost should occur
    private bool isBoosted = false; // Whether the enemy is currently boosted

    private void Update()
    {
        // Calculate the direction to the player
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90);

        // Move the enemy towards the player at the current speed
        float currentSpeed = movementSpeed * speedMultiplier;
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        // Check if it's time for a speed boost
        if (Time.time >= nextSpeedBoostTime)
        {
            if (!isBoosted)
            {
                // Boost the speed if not already boosted
                speedMultiplier *= 3f;
                isBoosted = true;
                Invoke("ResetSpeed", 2f); // Call ResetSpeed() after 2 seconds
            }

            // Schedule the next speed boost
            nextSpeedBoostTime += 8f;
        }
    }

    private void ResetSpeed()
    {
        // Reset the speed multiplier and boosted flag
        speedMultiplier /= 3f;
        isBoosted = false;
    }

    private void OnDestroy()
    {
        // Instantiate the explosion effect at the enemy's position
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
    }
}