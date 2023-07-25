/**

@class RayShooter
@brief This script is attached to the player in order to fire projectiles
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    /// <summary>
    /// The prefab object to launch
    /// </summary>
    public GameObject prefabToLaunch;   

    /// <summary>
    /// The force with which to launch the prefab object horizontally
    /// </summary>
    public float launchForce;     

    /// <summary>
    /// The force with which to launch the prefab object vertically
    /// </summary>
 
    public float verticalLaunchForce; 

    /// <summary>
    /// The variable to keep track of the current direction the player is facing
    /// </summary>
    public enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    private Direction currentDirection;

    void Start() {
        currentDirection = Direction.DOWN; // Default position when player is spawned in is down
    }

   

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get directional input for horizontal movement
        float verticalInput = Input.GetAxisRaw("Vertical"); // Get directional input for horizontal movement

        // If chain to determine current direction
        if (horizontalInput > 0) currentDirection = Direction.RIGHT;
        else if (horizontalInput < 0) currentDirection = Direction.LEFT;
        else if (verticalInput > 0) currentDirection = Direction.UP;
        else if (verticalInput < 0) currentDirection = Direction.DOWN;
        

        // If chain that responds to the current direction to launch a projectile when "T" is pushed
        if (currentDirection == Direction.RIGHT && Input.GetKeyDown(KeyCode.T))
        {
            Vector3 currentPos = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z); // Find current position
            GameObject newObject = Instantiate(prefabToLaunch, currentPos, Quaternion.identity); // Create instance of the projectile object
            newObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(launchForce, 0), ForceMode2D.Impulse); // Launch the projectile in this direction
            currentDirection = Direction.RIGHT; // Set the direction 
        }
        else if (currentDirection == Direction.LEFT& Input.GetKeyDown(KeyCode.T))
        {
            Vector3 currentPos = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z); // Find current position
            GameObject newObject = Instantiate(prefabToLaunch, currentPos, Quaternion.identity); // Create instance of the projectile object
            newObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(-launchForce, 0), ForceMode2D.Impulse); // Launch the projectile in this direction
            currentDirection = Direction.LEFT; // Set the direction 

        }
        else if (currentDirection == Direction.UP && Input.GetKeyDown(KeyCode.T))
        {

            Vector3 currentPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z); // Find current position
            GameObject newObject = Instantiate(prefabToLaunch, currentPos, Quaternion.identity); // Create instance of the projectile object
            newObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0, (verticalLaunchForce)), ForceMode2D.Impulse); // Launch the projectile in this direction
            currentDirection = Direction.UP; // Set the direction 

        }
        else if ( currentDirection == Direction.DOWN && Input.GetKeyDown(KeyCode.T))
        {

            Vector3 currentPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z); // Find current position
            GameObject newObject = Instantiate(prefabToLaunch, currentPos, Quaternion.identity); // Create instance of the projectile object
            newObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0, (-verticalLaunchForce)), ForceMode2D.Impulse); // Launch the projectile in this direction
            currentDirection = Direction.DOWN; // Set the direction 
            
        }

        
        
    }

    
}
