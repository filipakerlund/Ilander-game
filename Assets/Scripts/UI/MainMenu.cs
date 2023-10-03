using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button newGame;
    [SerializeField] Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(NewGame);
        quitButton.onClick.AddListener(Quit);
    }

    private void NewGame()
    {
        LevelManager.Instance.LoadNewGame();
    }
    private void Quit()
    {
        // The Application.Quit call is ignored in the Editor (hence the debug log message).
        Application.Quit();
        Debug.Log("Quitting application.");
    }
}
