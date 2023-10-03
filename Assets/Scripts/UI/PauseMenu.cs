using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] Button mainMenu;
    [SerializeField] Button exitButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button pauseButton;

    void Start()
    {
        mainMenu.onClick.AddListener(LoadMainMenu);
        exitButton.onClick.AddListener(Quit);
        continueButton.onClick.AddListener(Continue);
    }

    private void LoadMainMenu()
    {
        LevelManager.Instance.LoadMainMenu();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Quit()
    {
        // The Application.Quit call is ignored in the Editor (hence the debug log message).
        Application.Quit();
        Debug.Log("Quitting application.");
    }

    private void Continue()
    {
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}
