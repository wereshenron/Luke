/**

@class ExitItem
@brief This script is attached to all ExitItem objects to detect if a ExitItem has been eaten. This same logic will be used for other logic like picking up an item to move the player to the next level.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitItem : MonoBehaviour
{
    /**
    * @brief For every collision that happens with a ExitItem, the scene number will increment by 1 and the next scene will load
    *
    * @param other The collider of the object that collided with the ExitItem
*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Go to the next scene numner
        }
    }
}