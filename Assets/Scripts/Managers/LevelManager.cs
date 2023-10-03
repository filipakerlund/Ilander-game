using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        // singleton: check instance == null? Make debug message.
        Instance = this;
    }

    // Order of enum is important since we will reference an index number from the build settings.
    public enum Scene
    {
        MainMenu,
        Level01,
        Level02,
        Level03
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    //Loading the first level of the game.
    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    // Loads the next level. Take the active scene and go to the build settings and add 1 to the index.
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    // Prefab reference in this script for player1 and player2. (use serialized field).
    // Before you set the scene I config save the setting as 1 or 2 players. 
    // Create a new singleton to instantiate number of players.
    // Create functions for 2P(load manager): Set player2 active after the scene has loaded.
    // Make this load manager as a dont destroy on load.
}
