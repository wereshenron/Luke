/**

@class SaveGameLoader
@brief This script is utilized to check the input of the text box 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Code for all the text and textboxes in the save game scene
/// </summary>
public class SaveGameLoader : MonoBehaviour
{
    private string input;
    [SerializeField] GameObject invalid;

    /// <summary>
    /// method for checking the code of whats put in the textbox
    /// </summary>
    public void CodeReader(string s) {

         input = s;
         Debug.Log(input);
         
        /// <summary>
        /// Determines if the code is valid, if so load scene or do nothing
        /// </summary>
         switch (input) 
        {
            case "56b55f63":
                Debug.Log("Main Menu");
                SceneManager.LoadScene(0); // testing all valid codes will return to main menu for now
                break;
            case "07f844a5":
                Debug.Log("Level 1");
                SceneManager.LoadScene("Neighnborhood");
                break;
            case "71d95407":
                Debug.Log("Level 1 Boss");
                SceneManager.LoadScene("FirstBoss");
                break;
            case "9ef1151f":
                Debug.Log("Level 2");
                SceneManager.LoadScene("Park");
                break;
            case "36792ed7":
                Debug.Log("Level 2 Boss");
                SceneManager.LoadScene("SecondBoss");
                break;
            case "e9f62589":
                Debug.Log("Level 3");
                SceneManager.LoadScene("Woods");
                break;
            case "0b190767":
                Debug.Log("Level 3 Boss");
                SceneManager.LoadScene(0);
                break;
            case "7792b02a":
                Debug.Log("Level 4");
                SceneManager.LoadScene("City");
                break;
            case "b939db77":
                Debug.Log("Level 4 Boss");
                SceneManager.LoadScene(0);
                break;
            case "861d657b":
                Debug.Log("Easter Egg");
                SceneManager.LoadScene(0);
                break;
            default:
                Debug.Log("Invalid level ID");
                invalid.SetActive(true);
                break;
        }
    
         
    }

}
