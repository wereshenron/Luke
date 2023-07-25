
/**

@class AttackHitbox
@brief This script is attached to the player and projectiles in order to damage enemies 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a hitbox used for attacking enemies.
/// </summary>
public class AttackHitbox : MonoBehaviour
{
    /// <summary>
    /// The amount of damage dealt by this hitbox.
    /// </summary>
    public float attackDamage = 1f;

    /// <summary>
    /// The enemy that this hitbox has collided with.
    /// </summary>
    private BasicEnemy enemy;


    /// <summary>
    /// Called when a collision occurs between this hitbox and another object.
    /// </summary>
    /// <param name="collider">The object that this hitbox collided with.</param>
    void OnCollisionEnter2D(Collision2D collider)
    {
        /// <summary>
        /// Flag indicating whether the hitbox has already collided with an object.
        /// </summary>
        bool hasEntered = false;


        // If the collision happened on an enemy object and it hasn't already happened and the current hitbox isn't a projectile, continue to deal enemy damage from physical attack
        if (collider.gameObject.tag == "Enemy" && !hasEntered && gameObject.tag != "Throw")
        {
            enemy = collider.gameObject.GetComponent<BasicEnemy>();
            enemy.Health -= attackDamage;
            Debug.Log("Enemy hit for:" + attackDamage);
            hasEntered = true;
        }
        // If the collision happened on an enemy object and it hasn't already happened and the current hitbox is a projectile, continue to deal enemy damage from projectile attack
        else if (collider.gameObject.tag == "Enemy" && !hasEntered && gameObject.tag == "Throw")
        {
            enemy = collider.gameObject.GetComponent<BasicEnemy>();
            enemy.Health -= attackDamage;
            Debug.Log("Enemy hit by throw for:" + attackDamage);
            hasEntered = true;
            Destroy(gameObject);
        }
        // Any time the projectile game object hits anything that is not an enemy, it needs to be destroyed
        else if (gameObject.tag == "Throw")
        {
            Destroy(gameObject);
        }
    }
}
