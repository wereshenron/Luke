/**

@class ProjectileBehavior
@brief This script is attached to the projectiles used by bosses to multiply the projectiles
*/
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    /// <summary>
    /// The speed variable for the projectile speeds
    /// </summary>

    public float speed = 5f;

    /// <summary>
    /// The speed at which the projectile should spin
    /// </summary>
    public float spinSpeed = 360f; 

    /// <summary>
    /// The object which should be launched as a projectile
    /// </summary>
    public GameObject projectilePrefab;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Move the projectile in its forward direction
        transform.position += transform.up * speed * Time.deltaTime;

        // Rotate the projectile around its z-axis to make it spin
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

        // Check if the projectile is within 10 units of the player
        if (Vector2.Distance(transform.position, playerTransform.position) <= 10f)
        {
            // Call the method to shoot projectiles in all four directions
            ShootProjectiles();
            
            // Destroy the current projectile
            Destroy(gameObject);
        }
    }

    private void ShootProjectiles()
    {
        // Get the current position of the projectile
        Vector3 position = transform.position;

        // Shoot projectiles in all four directions
        Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 0f)); // Up
        Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 90f)); // Right
        Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 180f)); // Down
        Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 270f)); // Left
    }
}
