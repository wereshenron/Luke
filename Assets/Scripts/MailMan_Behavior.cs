/**

@class Mailman_Behavior
@brief This script is used to control mailmen behavior 
*/
using UnityEngine;

/// <summary>
/// This class is responsible for the behavior of individual mailmen.
/// </summary>
public class Mailman_Behavior : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; ///< Reference to the projectile prefab
    [SerializeField] private Transform luke; ///< Reference to Luke's transform
    [SerializeField] private float moveSpeed = 1f; ///< Speed of the mailman when moving towards Luke
    [SerializeField] private float throwInterval = 3f; ///< Interval between throwing projectiles

    private float throwTimer; ///< Timer to control the throwing of projectiles

    /// <summary>
    /// Initializes the script by finding Luke and setting up the throw timer.
    /// </summary>
    private void Start()
    {
        luke = GameObject.FindWithTag("Luke").transform;
        throwTimer = throwInterval;
    }

    /// <summary>
    /// Updates the mailman's position and handles projectile throwing.
    /// </summary>
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, luke.position, moveSpeed * Time.deltaTime);

        throwTimer -= Time.deltaTime;

        if (throwTimer <= 0f)
        {
            throwTimer = throwInterval;
            ThrowProjectile();
        }
    }

    /// <summary>
    /// Throws a projectile towards Luke.
    /// </summary>
    private void ThrowProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (luke.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
    }
}
