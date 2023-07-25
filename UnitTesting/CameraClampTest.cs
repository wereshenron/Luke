using NUnit.Framework;
using UnityEngine;

public class CameraClampTest
{
    [Test]
    public void TestCameraClamp()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        GameObject cameraObject = new GameObject();
        playerObject.transform.position = Vector3.zero;
        cameraObject.transform.position = Vector3.zero;
        CameraClamp cameraClamp = cameraObject.AddComponent<CameraClamp>();
        cameraClamp.playerTransform = playerObject.transform;
        cameraClamp.minX = -5;
        cameraClamp.maxX = 5;
        cameraClamp.minY = -5;
        cameraClamp.maxY = 5;

        // Act
        Vector3 desiredPosition = new Vector3(10f, 10f, 0f);
        Vector3 clampedPosition = cameraClamp.ClampCamera(desiredPosition);

        // Assert
        Assert.AreEqual(clampedPosition.x, cameraClamp.maxX - Camera.main.orthographicSize * 2f / Camera.main.aspect / 2f);
        Assert.AreEqual(clampedPosition.y, cameraClamp.maxY - Camera.main.orthographicSize);
    }
}
