using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The ConditionalItemPlacer class places an item in the game world if the boss does not exist.
/// </summary>
public class ConditionalItemPlacer : MonoBehaviour
{
    /// <summary>
    /// Name of the object to check for existence.
    /// </summary>
    public string objectName = "FirstBoss";
    public ItemPlacer itemPlacer;

    /// <summary>
    /// On Start, checks for the existence of the specified object and places an item if the object does not exist.
    /// </summary>
    void Start()
    {
        // Check if the specified object does not exist
        if (!DoesGameObjectExist(objectName))
        {
            // Place the item at the specified coordinates
            itemPlacer.PlaceItem(19, 16);
        }
    }

    /// <summary>
    /// Checks if a GameObject with the specified name exists in the game world.
    /// </summary>
    /// <param name="objectName">The name of the object to check for.</param>
    /// <returns>True if the GameObject exists, false otherwise.</returns>
    bool DoesGameObjectExist(string objectName)
    {
        // Find a GameObject with the specified name
        GameObject foundObject = GameObject.Find(objectName);
        // Return true if the GameObject is not null, indicating it exists
        return foundObject != null;
    }
}
