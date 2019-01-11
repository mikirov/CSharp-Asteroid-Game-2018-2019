using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour {

    public string GameScene = "Asteroids";
    public string MainMenu = "Menu";

    public void RestartGame()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
