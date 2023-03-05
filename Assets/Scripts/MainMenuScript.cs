using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private int playerHighScore = 0;

    private void Start()
    {
        playerHighScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        highScoreText.text = playerHighScore.ToString();
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}