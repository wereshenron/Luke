using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class BgScriptTests
{
    [Test]
    public void SingletonPatternWorksCorrectly()
    {
        GameObject bgScriptObj1 = new GameObject("BgScript1");
        BgScript bgScript1 = bgScriptObj1.AddComponent<BgScript>();

        GameObject bgScriptObj2 = new GameObject("BgScript2");
        BgScript bgScript2 = bgScriptObj2.AddComponent<BgScript>();

        bgScript1.Awake();
        bgScript2.Awake();

        Assert.AreEqual(bgScript1, BgScript.BgInstance);
        Assert.AreNotEqual(bgScript2, BgScript.BgInstance);
        Assert.IsTrue(bgScript2 == null);
    }

    [Test]
    public void AudioSourceIsAssignedOnStart()
    {
        GameObject bgScriptObj = new GameObject("BgScript");
        BgScript bgScript = bgScriptObj.AddComponent<BgScript>();
        bgScriptObj.AddComponent<AudioSource>();

        bgScript.Start();

        Assert.IsNotNull(bgScript.Audio);
    }
}
