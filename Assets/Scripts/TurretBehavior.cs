
/**

@class TurretBehavior
@brief This script is attached to turret characters in order to define their behavior
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behavior of the turret enemies
/// </summary>
public class TurretBehavior : MonoBehaviour
{

    /// <summary>
    /// The player transform in the scene
    /// </summary>
    public Transform playerTransform;

    /// <summary>
    /// The position of the player in the scene
    /// </summary>
    Vector2 playerPosition;

    /// <summary>
    /// The direction of the player
    /// </summary>
    Vector2 direction;

    /// <summary>
    /// The direction of the bullet
    /// </summary>
    Vector2 bulletDirection;

    /// <summary>
    /// The bullet gameObject
    /// </summary>
    GameObject bullet;

    /// <summary>
    /// The prefab of the bullet
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// The speed that the bullet flies at
    /// </summary>
    public float bulletSpeed = 2f;

    /// <summary>
    /// The rigidbody of the bullet
    /// </summary>
    Rigidbody2D bulletRigidBody;

    /// <summary>
    /// The bossbehavior script that this script references
    /// </summary>
    public BossBehavior bossBehavior;

    /// <summary>
    /// Called at the start of the scene
    /// </summary>
    void Start()
    {
        InvokeRepeating("FireTurret", 6.0f, 6.0f);
        bossBehavior = GameObject.FindObjectOfType<BossBehavior>();
    }

    /// <summary>
    /// Called once every frame
    /// </summary>
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90);
    }

    /// <summary>
    /// Fires an instantiated bullet in the direction of the player
    /// </summary>
    void FireTurret()
    {
        playerPosition = playerTransform.position;
        direction = playerPosition - (Vector2)transform.position;
        bulletDirection = direction.normalized;
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = bulletDirection * bulletSpeed;
    }

    /// <summary>
    /// Called when the turret is destroyed
    /// </summary>
    void OnDestroy()
    {
        bossBehavior.ChangeBossTag();
    }

}
