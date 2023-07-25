
/**

@class PlayerHealth
@brief This script is attached to the player in order to control where you are on the map
*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    /// <summary>
    /// The variable to keep track of current health status
    /// </summary>
    private float _health;

    /// <summary>
    /// The variable to keep track of max health status
    /// </summary>
    public float maxHealth;

    void Start() {
        _health = maxHealth;
    }
 


    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                Debug.Log("Player has died!");
                Destroy(gameObject);
                SceneManager.LoadScene("DeathScreen");
            }
        }
        get
        {
            return _health;
        }
    }
}