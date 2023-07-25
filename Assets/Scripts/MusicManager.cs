/**

@class MusicManager
@brief This script controls when the music turns on and off
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
   public Text toggleMusictxt;

   private void Start()
   {
        if(BgScript.BgInstance.Audio.isPlaying)
       {
            toggleMusictxt.text = "OFF";
       }
       else
       {
            toggleMusictxt.text = "ON";
       }
   }

    /// <summary>
    /// Turns Audio on and off when the button is pressed.
    /// </summary>
   public void MusicToggle()
   {
       if(BgScript.BgInstance.Audio.isPlaying)
       {
            BgScript.BgInstance.Audio.Pause();
            toggleMusictxt.text = "ON";
       }
       else
       {
            BgScript.BgInstance.Audio.Play();
            toggleMusictxt.text = "OFF";
       }
   }
}
