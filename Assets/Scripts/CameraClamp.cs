/**

@class CameraClamp
@brief This script is attached to the main camera in order to track the character in a smoothed, delayed fashion
*/

using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    /// <summary>
    /// The variable to keep track of the current position of the player
    /// </summary>
    public Transform playerTransform;

    /// <summary>
    /// The variable that defines the smoothness at which the camera moves behind a character
    /// </summary>
    public float smoothSpeed = 0.125f;

    /// <summary>
    /// The x/y coordinates of the offset of the camera
    /// </summary>
    public Vector2 offset;

    /// <summary>
    /// The x/y coordinates of the limits the camera can operate in 
    /// </summary>
    [SerializeField] public int minX, maxX, minY, maxY;

    /// <summary>
    /// Updates the position of the camera to follow the player with smoothing.
    /// </summary>
    private void FixedUpdate()
    {
        // Calculate the desired position of the camera based on the player's position and the offset
        Vector3 desiredPosition = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, transform.position.z);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = ClampCamera(smoothedPosition);
    }

    /// <summary>
    /// Clamps the camera's position to ensure it stays within specified boundaries.
    /// </summary>
    /// <param name="position">The desired position of the camera.</param>
    /// <returns>The clamped position of the camera.</returns>
    private Vector3 ClampCamera(Vector3 position)
    {
        // Calculate the dimensions of the camera based on its orthographic size and aspect ratio
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Calculate the minimum and maximum allowed x and y positions for the camera
        float minXPos = minX + cameraWidth / 2f;
        float maxXPos = maxX - cameraWidth / 2f;
        float minYPos = minY + cameraHeight / 2f;
        float maxYPos = maxY - cameraHeight / 2f;

        // Clamp the x and y positions of the camera within the specified boundaries
        float x = Mathf.Clamp(position.x, minXPos, maxXPos);
        float y = Mathf.Clamp(position.y, minYPos, maxYPos);

        // Return the clamped position of the camera
        return new Vector3(x, y, position.z);
    }

}