using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private PlayerController CreatePlayerControllerObject()
    {
        GameObject playerObject = new GameObject();
        playerObject.AddComponent<Rigidbody2D>();
        playerObject.AddComponent<Animator>();
        PlayerController playerController = playerObject.AddComponent<PlayerController>();

        return playerController;
    }

    [UnityTest]
    public IEnumerator TestPlayerMovement()
    {
        PlayerController playerController = CreatePlayerControllerObject();
        Vector3 initialPosition = playerController.transform.position;

        // Simulate movement input
        InputSystem.QueueStateEvent<KeyboardState>(Keyboard.current, new KeyboardState(Key.W));
        InputSystem.Update();

        yield return new WaitForSeconds(0.1f);

        Vector3 newPosition = playerController.transform.position;

        Assert.AreNotEqual(initialPosition, newPosition);
    }
}
