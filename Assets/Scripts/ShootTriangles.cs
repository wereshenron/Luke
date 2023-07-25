
/**

@class ShootTriangles
@brief This script is attached to the first boss enemy and is responsible for repeatedly shooting out triangles
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the boss to fire triangles at the player
/// </summary>
public class ShootTriangles : MonoBehaviour
{
    /// <summary>
    /// The prefab projectile to be launched
    /// </summary>
    public GameObject prefabProjectile;

    /// <summary>
    /// The force that the projectile is launched with
    /// </summary>
    public float launchForce = 5f;

    /// <summary>
    /// The force that the projectile is launched with in the vertical direction
    /// </summary>
    public float verticalLaunchForce = 15f;

    /// <summary>
    /// The interval at which the time is checked
    /// </summary>
    public float updateInterval = 2f;

    /// <summary>
    /// The coroutine that is called alongside this script
    /// </summary>
    private IEnumerator coroutine;


    /// <summary>
    /// Called at the start of the scene and begins the coroutine
    /// </summary>
    void Start()
    {
        coroutine = shoot();
        StartCoroutine(coroutine);

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Shoots projectiles in all directions surrounding the boss character
    /// </summary>
    IEnumerator shoot() {
        while (true) {
            Vector3 position1 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            GameObject shot1 = Instantiate(prefabProjectile, position1, Quaternion.identity);
            Physics2D.IgnoreCollision(shot1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot1.GetComponent<Rigidbody2D>().AddForce( new Vector2(transform.position.x * launchForce, 0), ForceMode2D.Impulse);

            Vector3 position2 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
            GameObject shot2 = Instantiate(prefabProjectile, position2, Quaternion.identity);
             Physics2D.IgnoreCollision(shot2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot2.GetComponent<Rigidbody2D>().AddForce( new Vector2(-transform.position.x * launchForce, 0), ForceMode2D.Impulse);

            Vector3 position3 = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            GameObject shot3 = Instantiate(prefabProjectile, position3, Quaternion.identity);
            Physics2D.IgnoreCollision(shot3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot3.GetComponent<Rigidbody2D>().AddForce( new Vector2(0, transform.position.y * verticalLaunchForce), ForceMode2D.Impulse);

            Vector3 position4 = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
            GameObject shot4 = Instantiate(prefabProjectile, position4, Quaternion.identity);
            Physics2D.IgnoreCollision(shot4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -transform.position.y * verticalLaunchForce), ForceMode2D.Impulse);

            Vector3 position5 = new Vector3(transform.position.x + 3, transform.position.y + 3, transform.position.z);
            GameObject shot5 = Instantiate(prefabProjectile, position5, Quaternion.identity);
            Physics2D.IgnoreCollision(shot5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot5.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x * launchForce, transform.position.y * launchForce), ForceMode2D.Impulse);

            Vector3 position6 = new Vector3(transform.position.x + 3, transform.position.y - 3, transform.position.z);
            GameObject shot6 = Instantiate(prefabProjectile, position6, Quaternion.identity);
            Physics2D.IgnoreCollision(shot6.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot6.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x * launchForce, -transform.position.y * launchForce), ForceMode2D.Impulse);

            Vector3 position7 = new Vector3(transform.position.x - 3, transform.position.y + 3, transform.position.z);
            GameObject shot7 = Instantiate(prefabProjectile, position7, Quaternion.identity);
            Physics2D.IgnoreCollision(shot7.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot7.GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.position.x * launchForce, transform.position.y * launchForce), ForceMode2D.Impulse);

            Vector3 position8 = new Vector3(transform.position.x - 3, transform.position.y - 3, transform.position.z);
            GameObject shot8 = Instantiate(prefabProjectile, position8, Quaternion.identity);
            Physics2D.IgnoreCollision(shot8.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shot8.GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.position.x * launchForce, -transform.position.y * launchForce), ForceMode2D.Impulse);

            yield return new WaitForSeconds(updateInterval);
        }
    }
}
