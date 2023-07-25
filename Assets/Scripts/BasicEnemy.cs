/**

@class BasicEnemy
@brief This script is attached to enemies in order to track the enemy's health
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    /// <summary>
    /// The variable to keep track of current health status
    /// </summary>
    public float _health = 3f;
    private WalkerGenerator walkerGenerator;

    //find the enemies variable to decrement in walkergenerator
    void Start()
    {
        walkerGenerator = FindObjectOfType<WalkerGenerator>();
    }

    /// <summary>
    /// The variable to structure the end-of-life feature of the enemy
    /// </summary>
    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                Debug.Log("Enemy has died!");
                Destroy(gameObject);
                //triggers enemy destroyed method to decrement number of enemies in scene
                walkerGenerator.EnemyDestroyed();
            }
        }
        get
        {
            return _health;
        }
    }
    
   

   

}
