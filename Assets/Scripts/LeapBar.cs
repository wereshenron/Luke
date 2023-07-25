/**

@class LeapBar
@brief This script is attached to a HealthBar object to create a visual indication of the player's health
*/
using UnityEngine;
using UnityEngine.UI;

public class LeapBar : MonoBehaviour
{


    /// <summary>
    /// Reference to the current player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Reference to the current player's health
    /// </summary>
    private LeapForward playerCooldown;

    /// <summary>
    /// Reference to the main camera
    /// </summary>
    private Camera mainCamera;


    /// <summary>
    /// Width of the health bar
    /// </summary>
    public float barWidth = 70f;

    /// <summary>
    /// Height of the health bar
    /// </summary>
    public float barHeight = 10f;

    /// <summary>
    /// Color of the health bar
    /// </summary>
    public Color barColor = Color.green;

    /// <summary>
    /// Width of the border
    /// </summary>
    public float borderWidth = 1f;

    /// <summary>
    /// Color of the border
    /// </summary>
    public Color borderColor = Color.black;

    private float maxTimeToWait;



    private void Awake()
    {
        mainCamera = Camera.main;    // Get a reference to the main camera
        playerCooldown = player.GetComponent<LeapForward>();
        maxTimeToWait = playerCooldown.timeToWait;
    }

    private void OnGUI()
    {// Set the position and dimensions of the health bar
        float barX = 10f;
        float barY = 10f;
        float healthPercentage = (float)playerCooldown.timeToWait / maxTimeToWait;
        float barWidthScaled = barWidth * healthPercentage;
        Rect barRect = new Rect(barX, barY + 25, barWidthScaled, barHeight);

        // Draw the border around the health bar
        Rect borderRect = new Rect(barX - borderWidth, barY - borderWidth+ 25, barWidth + borderWidth * 2, barHeight + borderWidth * 2);
        GUI.color = borderColor;
        GUI.DrawTexture(borderRect, Texture2D.whiteTexture);

        // Draw the health bar using a colored rectangle
        GUI.color = barColor;
        GUI.DrawTexture(barRect, Texture2D.whiteTexture);
    }

    private void LateUpdate()
    {
        // Set the position of the health bar to the top left corner of the camera's view
        Vector3 viewportPos = new Vector3(0.05f, 0.99f, 0f);
        Vector3 worldPos = mainCamera.ViewportToWorldPoint(viewportPos);
        transform.position = worldPos;
    }


}
