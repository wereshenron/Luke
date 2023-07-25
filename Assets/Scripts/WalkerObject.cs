/**

@class WalkerObject
@brief This script is meant to define the walkers that will step through the grid and place each tile
*/
using UnityEngine;

public class WalkerObject : MonoBehaviour
{

    /// <summary>
    /// The variable to keep track of the current walker position
    /// </summary>
    public Vector2 Position;

    /// <summary>
    /// The variable to keep track of the current walker direction
    /// </summary>    
    public Vector2 Direction;

    /// <summary>
    /// The variable to keep track of the current walker's chance to change state
    /// </summary>  
    public float ChanceToChange;

    /// <summary>
    /// The code that sets all of the variables given 
    /// </summary>  
    public WalkerObject(Vector2 pos, Vector2 dir, float chanceToChange)
    {
        Position = pos;
        Direction = dir;
        ChanceToChange = chanceToChange;
    }
}
