using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviorTest
{
    [Test]
    public void TestNewGameButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        int expectedSceneNumber = 5;

        // Act
        mainMenu.NewGame();

        // Assert
        Assert.AreEqual(expectedSceneNumber, SceneManager.GetActiveScene().buildIndex);
    }

    [Test]
    public void TestStartGameButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        int expectedSceneNumber = 1;

        // Act
        mainMenu.StartGame();

        // Assert
        Assert.AreEqual(expectedSceneNumber, SceneManager.GetActiveScene().buildIndex);
    }

    [Test]
    public void TestLoadGameButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        int expectedSceneNumber = 3;

        // Act
        mainMenu.LoadGame();

        // Assert
        Assert.AreEqual(expectedSceneNumber, SceneManager.GetActiveScene().buildIndex);
    }

    [Test]
    public void TestSettingsButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        int expectedSceneNumber = 4;

        // Act
        mainMenu.Settings();

        // Assert
        Assert.AreEqual(expectedSceneNumber, SceneManager.GetActiveScene().buildIndex);
    }

    [Test]
    public void TestCreditsButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        int expectedSceneNumber = 2;

        // Act
        mainMenu.CreditsButton();

        // Assert
        Assert.AreEqual(expectedSceneNumber, SceneManager.GetActiveScene().buildIndex);
    }

    [Test]
    public void TestBackButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        int expectedSceneNumber = 0;

        // Act
        mainMenu.BackButton();

        // Assert
        Assert.AreEqual(expectedSceneNumber, SceneManager.GetActiveScene().buildIndex);
    }

    [Test]
    public void TestQuitGameButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        Application.Quit();
        bool isQuitting = Application.isQuit;

        // Act
        mainMenu.QuitGame();

        // Assert
        Assert.IsTrue(isQuitting);
    }

    [Test]
    public void TestPauseButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        GameObject pauseMenu = new GameObject();
        GameObject pauseButton = new GameObject();
        mainMenu._pauseMenu = pauseMenu;
        mainMenu._pausebutton = pauseButton;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);

        // Act
        mainMenu.PauseButton();

        // Assert
        Assert.AreEqual(0f, Time.timeScale);
        Assert.IsTrue(pauseMenu.activeSelf);
        Assert.IsFalse(pauseButton.activeSelf);
    }

    [Test]
    public void TestResumeButton()
    {
        // Arrange
        MainMenuBehavior mainMenu = new MainMenuBehavior();
        GameObject pauseMenu = new GameObject();
        GameObject pauseButton = new GameObject();
        mainMenu._pauseMenu = pauseMenu;
        mainMenu._pausebutton = pauseButton;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);

        // Act
        mainMenu.ResumeButton();

        // Assert
        Assert.AreEqual(1.0f, Time.timeScale);
        Assert.IsFalse(pauseMenu.activeSelf);
        Assert.IsTrue(pauseButton.activeSelf);
    }
}
