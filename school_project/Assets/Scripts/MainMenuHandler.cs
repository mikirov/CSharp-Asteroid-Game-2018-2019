using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    public string PVEGame = "Asteroids";
    public string PVAiGame = "Enemies";
    public string BossBattle = "BossBattle";

    public void loadPVE()
    {
        SceneManager.LoadScene(PVEGame);
    }
    public void loadPvAI()
    {
        SceneManager.LoadScene(PVAiGame);
    }
    public void loadBossBattle()
    {
        SceneManager.LoadScene(BossBattle);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
