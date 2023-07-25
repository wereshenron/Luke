/**

@class SceneFade 
@brief This script is attached to scenes and is utilized to help fade in scenes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The main function for fading in scenes
/// </summary>
public class SceneFade : MonoBehaviour
{
    
    /// <summary>
    /// The time it takes for the fade to complete in seconds.
    /// </summary>
    public float fadeTime = 1.0f;

    /// <summary>
    /// The time it takes for the fade to complete in seconds.
    /// </summary>
    // The UI panel that will be used for the fade.
    public GameObject fadePanel;

    /// <summary>
    /// The name of the next scene to load.
    /// </summary>
    public string nextSceneName;

    // The color to fade to and from.
    private Color fadeColor = Color.black;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Set the initial color of the fade panel.
        fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;

        // Fade the panel in over the specified time.
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // Set the color of the fade panel to the target color.
        fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;

        // Fade the panel out over the specified time.
        for (float t = 0.0f; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, t / fadeTime);
            fadePanel.GetComponent<UnityEngine.UI.Image>().color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }

        // Load the next scene.
        SceneManager.LoadScene(nextSceneName);
    }
}
