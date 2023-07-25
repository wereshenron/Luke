/**

@class SfxManager
@brief This script controls the button click audio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls button clicking behavior and audio.
/// </summary>
public class SfxManager : MonoBehaviour
{
    // Declare a public AudioSource variable to store the audio source component
    public AudioSource Audio;

    // Declare a public AudioClip variable to store the click sound clip
    public AudioClip Click;

    public static SfxManager sfxInstance;
    
     // This method is called when the script instance is being loaded
     private void Awake()
    {
        // If there is already a BgScript instance and it is not the current instance, 
        // destroy the current instance
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // If there is no instance, set the current instance as the static instance 
        // and make sure it is not destroyed when loading a new scene
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
