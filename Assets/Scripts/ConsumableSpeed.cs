/**

@class ConsumableSpeed
@brief This script is attached to all ConsumableSpeed objects to detect if a ConsumableSpeed has been eaten. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles interactions with ConsumableSpeed objects, applying a temporary speed boost to the player upon collision.
/// </summary>
public class ConsumableSpeed : MonoBehaviour
{
    /// <summary>
    /// Duration of the speed boost applied to the player in seconds.
    /// </summary>
    public float speedBoostDuration = 5f;

    /// <summary>
    /// Detects when the player enters the trigger collider and applies the speed boost effect to the player.
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {   // Check if the other collider has a "Player" tag
        if (other.gameObject.tag == "Player")
        {
            // Get the PlayerController component from the other game object
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            // If the playerController is not null, apply the speed boost
            if (playerController != null)
            {
                // Start the coroutine that applies the speed boost and waits for its duration
                other.gameObject.GetComponent<PlayerController>().StartCoroutine(playerController.ApplySpeedBoost(speedBoostDuration));
            }
            Destroy(gameObject); // Remove the consumable object from the game once it is interacted with, or picked up
        }
    }
}







