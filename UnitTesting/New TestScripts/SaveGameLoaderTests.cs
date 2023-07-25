using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SaveGameLoaderTests
{
    private SaveGameLoader CreateSaveGameLoaderObject()
    {
        GameObject loaderObject = new GameObject();
        SaveGameLoader loader = loaderObject.AddComponent<SaveGameLoader>();
        loaderObject.AddComponent<GameObject>();

        return loader;
    }

    [UnityTest]
    public IEnumerator TestCodeReader()
    {
        SaveGameLoader loader = CreateSaveGameLoaderObject();

        int initialSceneIndex = SceneManager.GetActiveScene().buildIndex;
        loader.CodeReader("56b55f63");
        yield return null;

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Assert.AreEqual(initialSceneIndex, newSceneIndex - 1);
    }
}
