/**

@class BaseEnemyAttackHitbox
@brief This script is attached to enemies in order to track player collisions
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAttackHitbox : MonoBehaviour
{

    /// <summary>
    /// The amount of damage dealt by physical damage
    /// </summary>
    public float attackDamage = 1f;

    /// <summary>
    /// The amount of damage dealt by projectile damage
    /// </summary>
    public float projectileDamage = 1f;

    /// <summary>
    /// A true/false variable of whether the player is in the middle of the "leap" animation 
    /// </summary>
    public bool playerIsLeaping;


    private PlayerHealth playerHealth; // The variable to define the player's health status
    private LeapForward player; // The variable to access the LeapForward component of the player



    /// <summary>
    /// Called when a collision occurs between this hitbox and another object.
    /// </summary>
    /// <param name="collider">The object that this hitbox collided with.</param>
    void OnCollisionEnter2D(Collision2D collider)
    {

        bool hasEntered = false; // Reset the entered status if this is a new collision 

        // If the collision happens with the player object, determine first if it is leaping 
        if (collider.gameObject.tag == "Player")
        {
            player = collider.gameObject.GetComponent<LeapForward>();
            playerIsLeaping = player.isLeaping;
        }

        // If the collision happened on an enemy object and it hasn't already happened and the current hitbox isn't a projectile, continue to deal enemy damage from physical attack
        if (collider.gameObject.tag == "Player" && !hasEntered && gameObject.tag != "Projectile" && !playerIsLeaping)
        {
            playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Health -= attackDamage;
            Debug.Log("Player hit for: " + attackDamage);
            hasEntered = true;
        }

        // If the collision happened on an player object and it hasn't already happened and the current hitbox is a projectile, continue to deal player damage from projectile attack
        else if (collider.gameObject.tag == "Player" && !hasEntered && gameObject.tag == "Projectile")
        {
            playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Health -= projectileDamage;
            Debug.Log("Player hit by projectile for: " + projectileDamage);
            hasEntered = true;
            Destroy(gameObject);
        }

        // Any time the projectile game object hits anything that is not an enemy, it needs to be destroyed
        else if (gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }

    }
}
