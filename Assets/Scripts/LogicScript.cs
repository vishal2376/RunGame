using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int playerScore = 0;
    private int playerHighScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fpsText;
    public GameObject gameOverScreen;

    public float deltaTime = 0;


    private void Start()
    {
        playerHighScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }

    private void Update()
    {
        UpdateFPS();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (playerScore > playerHighScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", playerScore);
        }
    }

    private void UpdateFPS()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        var fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScreen");
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}