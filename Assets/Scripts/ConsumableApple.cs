/**

@class ConsumableApple
@brief This script is attached to all ConsumableApple objects to detect if an apple has been eaten to give the player health 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableApple : MonoBehaviour
{

    private PlayerHealth player;

    /// <summary>
    /// This is the variable to keep track of how much health to give back to the player
    /// </summary> 
    public int healAmount;

    /**
    * @brief For every collision that happens with a ConsumableItem, check if it is has the "Dog" tag which has been given to the player in the editor. If it is the dog, destroy the object. This code will be changed at a later time in order to make the ConsumableItem give the "Dog" health when it's picked up
    *
    * @param other The collider of the object that collided with the ConsumableItem
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject); // Remove the consumable object from the game once it is interacted with, or picked up
            player = other.GetComponent<PlayerHealth>();
            if (player.Health < player.maxHealth) player.Health += healAmount;
            
        }
    }
}