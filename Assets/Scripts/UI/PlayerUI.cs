using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject gameEndScreen;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI scoreText;
    public Button retryButton;
    public Button nextLevelButton;

    void Start()
    {
        retryButton.onClick.AddListener(Retry);
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void Retry()
    {
        LevelManager.Instance.ReloadScene();
    }
    private void NextLevel()
    {
        // If level is Level 3 then don't show the button.
        LevelManager.Instance.LoadNextLevel();
    }
    public void CrashScreen()
    {
        // If (crash == true) then display crash-text and don't award points. Give option to retry level.
        gameEndScreen.SetActive(true);
        endText.text = "Shuttle Crashed!";
        retryButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(false);
    }
    public void LandScreen()
    {
        // If (crash == false) then display land-text and award points. Give option to go to next level.
        gameEndScreen.SetActive(true);
        endText.text = "Shuttle Landed Safely";
        retryButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(true);
    }
    public void LandingScore(int score)
    {
        // If player lands (crash == false) then assign score (based on time passed and landing site) add calc  for platforms landscore *= * scoreToAdd; (int scoreToAdd)
        scoreText.text = "Score: " + score.ToString();
    }
}
