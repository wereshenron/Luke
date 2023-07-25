/**

@class PlayerController
@brief This script is attached to the player in order to control where you are on the map
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// The speed variable for the character
    /// </summary>
    public float moveSpeed;

    // Private variables
    private Animator animator; // Reference to the animator component of this object
    private Rigidbody2D rb; // Reference to the RigidBody2d component of this object
    private PlayerInputActions PlayerControls; // Reference to the PlayerInputActions component of this object
    private Vector2 moveDirection = Vector2.zero; // Reference to the direction of this object's movement 
    private InputAction move; // Reference to the InputAction move
    private InputAction fire; // Reference to the InputAction fire
    private InputAction attack; // Reference to the InputAction attack
    /// <summary>
    /// Varaibles needed to handle speed boost item
    /// </summary>
    public float speedBoostMultiplier = 2f;
    private float originalMoveSpeed;

    private void Awake()
    {
        // Get necessary components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // Initialize input system
        PlayerControls = new PlayerInputActions();
        originalMoveSpeed = moveSpeed;
    }

    private void OnEnable()
    {
        // Enable input actions
        move = PlayerControls.Player.Move;
        move.Enable();

        fire = PlayerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;//calls the Fire method

        attack = PlayerControls.Player.Attack;
        attack.Enable();
        attack.performed += Attack;//calls the bite method
    }

    private void OnDisable()
    {
        // Disable input actions
        move.Disable();
        fire.Disable();
        attack.Disable();
    }

    void Update()
    {
        // Get movement input
        moveDirection = move.ReadValue<Vector2>();

        // Send X and Y values to animator
        if (moveDirection.x != 0 || moveDirection.y != 0)
        { 
            // If player is moving
            animator.SetFloat("X", moveDirection.x); // Set animation parameter for horizontal movement
            animator.SetFloat("Y", moveDirection.y); // Set animation parameter for vertical movement
            animator.SetBool("IsWalking", true); // Set animation parameter for walking
        }
        else
        { 
            // If player is not moving
            animator.SetBool("IsWalking", false); // Set animation parameter for not walking
        }  
    }

    private void FixedUpdate()
    {
        // Move the player object based on the player movement input and move speed
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        // When fire (mouse or trigger) is pressed
        //animator.SetBool("IsAttacking", true);
        Debug.Log("Player Fired");
    }

    private void Attack(InputAction.CallbackContext context)
    {
        // When fire (mouse or trigger) is pressed
        animator.SetBool("IsAttacking", true);
    }
    public void ResetAttackParameter()
    {
        // Method to call for event animations
        animator.SetBool("IsAttacking", false); // Turn off attacking once animation completes
    }

    /// <summary>
    /// Changes speed of Player when called for a specified amount of time 
    /// </summary>
    public IEnumerator ApplySpeedBoost(float duration)
    {
        moveSpeed *= speedBoostMultiplier;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;
    }
}
