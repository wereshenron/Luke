/**

@class BgScript
@brief This script is used to play background music to the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public static BgScript BgInstance;
    public AudioSource Audio;

    private void Awake()
    {
        if(BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
}
