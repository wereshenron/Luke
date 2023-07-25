/**

@class ItemPlacer
@brief This script is has been made specifically for the boss enemies so the exit prefab will spawn on death.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Places an item at a specified location regardless of what tile is present
/// </summary>
public class ItemPlacer : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // Assign the item prefab in the Inspector

    /// <summary>
    /// Places an item at the specified x and y coordinates in the game world.
    /// </summary>
    /// <param name="x">The x-coordinate for the item's position.</param>
    /// <param name="y">The y-coordinate for the item's position.</param>
    public void PlaceItem(float x, float y)
    {
        // Create a new Vector3 with the specified x and y coordinates
        Vector3 position = new Vector3(x, y, 0);
        // Instantiate the itemPrefab at the calculated position with no rotation
        Instantiate(itemPrefab, position, Quaternion.identity);
    }
}
