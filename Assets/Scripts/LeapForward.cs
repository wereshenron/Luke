/**

@class LeapForward
@brief This script is attached to the player in order to give the player a jump attack
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapForward : MonoBehaviour
{
    /// <summary>
    /// The force to apply during the leap
    /// </summary>
    public float leapForce = 10.0f;

    [SerializeField] public float timeToWait;
    

    /// <summary>
    /// Flag to test if the player is leaping
    /// </summary>
    public bool isLeaping;
    private Rigidbody2D characterRigidbody; // Reference to the player's rigidbody
    private bool canLeap = true; // Flag to control if the player can leap

    private Coroutine leapForceCoroutine; // Coroutine to control the leap force application
    private float elapsedTime = 0f; // Variable to keep track of the elapsed time during the leap
    private BaseEnemyAttackHitbox enemy; // Reference to enemy hitbox in order to let it know if player is leaping or not
    private float maxTimeToWait;


    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>(); // Access the player's rigidbody directly
        maxTimeToWait = timeToWait;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get directional input for horizontal movement
        float verticalInput = Input.GetAxisRaw("Vertical"); // Get directional input for vertical movement

        // Check if the player can leap and if the F key is pressed
        if (canLeap && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("leaping");
            isLeaping = true;
            StartCoroutine(LeapDuration());
            leapForceCoroutine = StartCoroutine(ApplyLeapForce(horizontalInput, verticalInput));
        }
    }

    // Coroutine to control the duration between leaps

    IEnumerator LeapDuration()
    {


        canLeap = false; // Disable leaping
        Debug.Log("Leaping is on cooldown for " + timeToWait + " seconds.");

        timeToWait = 0.0f;
        while (timeToWait < maxTimeToWait)
        {
            Debug.Log("Remaining cooldown time: " + timeToWait + " seconds.");
            yield return new WaitForSeconds(1f);
            timeToWait++;
        }
        Debug.Log("Leaping is now available!");
        // Enable leaping again
        canLeap = true;
    }


    // Coroutine to apply leap force to the player's rigidbody
    IEnumerator ApplyLeapForce(float horizontalInput, float verticalInput)
    {
        elapsedTime = 0f; // Reset elapsedTime when starting the ApplyLeapForce coroutine
        // Apply leap force as long as elapsedTime is less than 1
        while (elapsedTime < 1)
        {
            // Apply leap force based on the player's movement direction
            if (horizontalInput > 0)
            {
                characterRigidbody.AddForce(transform.right * leapForce * 10);
            }
            else if (horizontalInput < 0)
            {
                characterRigidbody.AddForce(-transform.right * leapForce * 10);
            }
            else if (verticalInput > 0)
            {
                characterRigidbody.AddForce(transform.up * leapForce * 10);
            }
            else if (verticalInput < 0)
            {
                characterRigidbody.AddForce(-transform.up * leapForce * 10);
            }

            elapsedTime += Time.deltaTime; // Update elapsedTime with the time passed since the last frame
            yield return null; // Wait for the next frame before continuing the coroutine
        }
        Debug.Log("not leaping");
        isLeaping = false;
    }
}