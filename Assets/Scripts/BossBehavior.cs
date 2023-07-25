
/**

@class BossBehavior
@brief This script is attached to the first boss character and defines its behavior
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Describes the behavior of the first boss character
/// </summary>
public class BossBehavior : MonoBehaviour
{

    /// <summary>
    /// Stores the name of the west turret
    /// </summary>
    public string westTurretName = "WestTurret";

    /// <summary>
    /// Stores the name of the south turret
    /// </summary>
    public string southTurretName = "SouthTurret";

    /// <summary>
    /// Stores the name of the north turret
    /// </summary>
    public string northTurretName = "NorthTurret";

    /// <summary>
    /// Stores the name of the east turret
    /// </summary>
    public string eastTurretName = "EastTurret";

    /// <summary>
    /// Stores the name of the updated tag
    /// </summary>
    public string updatedTag = "Enemy";

    /// <summary>
    /// A reference to the sprite renderer
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// A reference to the item placed
    /// </summary>
    public ItemPlacer itemPlacer;

    /// <summary>
    /// Called at the start of the scene
    /// </summary>
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// Changes the tag of the boss
    /// </summary>
   public void ChangeBossTag()
   {

    bool turretsExist = false;

    if (GameObject.Find(westTurretName))
    {
        turretsExist = true;
    }
    if (GameObject.Find(eastTurretName))
    {
        turretsExist = true;
    }
    if (GameObject.Find(northTurretName))
    {
        turretsExist = true;
    }
    if (GameObject.Find(southTurretName))
    {
        turretsExist = true;
    }

    if (!turretsExist)
    {
        gameObject.tag = updatedTag;
        spriteRenderer.material.color = Color.green;
        itemPlacer.PlaceItem(19, 16);
    }

   }

}
