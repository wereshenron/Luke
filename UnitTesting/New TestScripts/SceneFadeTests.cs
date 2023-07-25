using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class SceneFadeTests
{
    private SceneFade CreateSceneFadeObject()
    {
        GameObject sceneFadeObject = new GameObject();
        SceneFade sceneFade = sceneFadeObject.AddComponent<SceneFade>();
        sceneFade.fadePanel = new GameObject("FadePanel");
        sceneFade.fadePanel.AddComponent<Image>();
        sceneFade.nextSceneName = "TestScene";

        return sceneFade;
    }

    [UnityTest]
    public IEnumerator TestFadeIn()
    {
        SceneFade sceneFade = CreateSceneFadeObject();
        yield return new WaitForSeconds(sceneFade.fadeTime + 0.1f);

        Color finalColor = sceneFade.fadePanel.GetComponent<Image>().color;
        Assert.AreEqual(0f, finalColor.a, 0.1f);
    }
}
