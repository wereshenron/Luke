using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LeapForwardTest
{
    [UnityTest]
    public IEnumerator TestLeapForward()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        playerObject.AddComponent<LeapForward>();
        Rigidbody2D playerRigidbody = playerObject.AddComponent<Rigidbody2D>();
        playerObject.transform.position = Vector3.zero;
        float leapForce = 10.0f;

        // Act
        playerObject.GetComponent<LeapForward>().leapForce = leapForce;
        playerObject.GetComponent<LeapForward>().isLeaping = true;
        playerRigidbody.velocity = Vector2.zero;
        playerObject.GetComponent<LeapForward>().StartCoroutine(playerObject.GetComponent<LeapForward>().ApplyLeapForce(1f, 0f));
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.IsTrue(playerRigidbody.velocity.x > 0);
        Assert.IsFalse(playerObject.GetComponent<LeapForward>().isLeaping);
    }
}
