/**

@class ConsumableItem
@brief This script is attached to all ConsumableItem objects to detect if a ConsumableItem has been eaten. This same logic will be used for other logic like picking up an item to move the player to the next level.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : MonoBehaviour
{
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
        }
    }
}