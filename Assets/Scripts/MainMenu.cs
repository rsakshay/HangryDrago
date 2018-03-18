using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string mainLevelName = "Prod";
    public string MainMenuName = "MainMenu";

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainLevelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
    }
}
