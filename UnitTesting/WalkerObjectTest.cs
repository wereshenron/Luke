using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WalkerObjectTests
{
    [Test]
    public void WalkerObjectInitialization()
    {
        Vector2 position = new Vector2(0, 0);
        Vector2 direction = new Vector2(1, 0);
        float chanceToChange = 0.2f;

        WalkerObject walker = new WalkerObject(position, direction, chanceToChange);

        Assert.AreEqual(position, walker.Position);
        Assert.AreEqual(direction, walker.Direction);
        Assert.AreEqual(chanceToChange, walker.ChanceToChange);
    }
}
