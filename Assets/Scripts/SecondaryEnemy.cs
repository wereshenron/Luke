
/**

@class SecondaryEnemy
@brief This script is attached to the secondary enemies during the second boss fight to define their behavior
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behavior for the secondary enemies during the second boss fight
/// </summary>
public class SecondaryEnemy : MonoBehaviour
{

    /// <summary>
    /// The player character in the scene
    /// </summary>
    public Transform player;

    /// <summary>
    /// The rigidbody of the character
    /// </summary>
    Rigidbody2D rb;

    /// <summary>
    /// The position of the secondary enemy that the script is attached to
    /// </summary>
    Vector2 positionOfPlayer;

    /// <summary>
    /// The direction of the bullet
    /// </summary>
    Vector2 bulletDirection;

    /// <summary>
    /// The direction that the player is moving
    /// </summary>
    Vector2 direction;

    /// <summary>
    /// The bullet object that is spawned in the scene
    /// </summary>
    GameObject bullet;

    /// <summary>
    /// The prefab of the bullet to be instantiated
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// The rigidbody of the bullet
    /// </summary>
    Rigidbody2D bulletRigidBody;

    /// <summary>
    /// The speed that the bullet flies at
    /// </summary>
    public float bulletSpeed = 5f;

    /// <summary>
    /// The speed of the enemy
    /// </summary>
    public float speed = 3f;

    /// <summary>
    /// Called at the start of the scene
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ShootAtPlayer", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        positionOfPlayer = player.position;
        rb.MovePosition(rb.position + positionOfPlayer * speed * Time.deltaTime);
    }

    /// <summary>
    /// Instantiates a projectile and applies for to it to launch it in the direction of the player
    /// </summary>
    void ShootAtPlayer()
    {
        positionOfPlayer = player.position;
        direction = positionOfPlayer - (Vector2)transform.position;
        bulletDirection = direction.normalized;
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = bulletDirection * bulletSpeed;
    }
}
