using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WanderAITests
{
    private WanderAI CreateWanderAIObject()
    {
        GameObject enemyObject = new GameObject();
        enemyObject.AddComponent<Rigidbody2D>();
        enemyObject.AddComponent<Animator>();
        WanderAI wanderAI = enemyObject.AddComponent<WanderAI>();

        return wanderAI;
    }

    [UnityTest]
    public IEnumerator TestEnemyMovement()
    {
        WanderAI wanderAI = CreateWanderAIObject();
        Vector3 initialPosition = wanderAI.transform.position;

        yield return new WaitForSeconds(1.0f);

        Vector3 newPosition = wanderAI.transform.position;

        Assert.AreNotEqual(initialPosition, newPosition);
    }
}
