using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text endModelScoreText;
    public Text highScoreText;
    public GameObject scoreText;
    public GameObject gameOver;
    public GameObject scoreBoard;
    public GameObject playButton;
    public GameObject menuButton;
    public GameObject resumeButton;
    public GameObject pauseButton;

    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;
    public GameObject platMedal;

    public Image newFlag;

    public int score;
    public int highScore;
    public float updatedImageDisplayTime = 2f;
    private bool highScoreUpdated = false;

    // PlayerPref Keys
    private const string HighScoreKey = "HighScore";

    public void Start()
    {
        LoadHighScore();
        UpdateUI();
        newFlag.gameObject.SetActive(false);

        score = 0;
        scoreText.GetComponent<Text>().text = score.ToString();

        gameOver.SetActive(false); 
        scoreBoard.SetActive(false);
        playButton.SetActive(false);
        scoreText.SetActive(true);
        menuButton.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void UpdateUI()
    {
        highScoreText.text = highScore.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
            highScoreUpdated = true;
            Invoke("ResetHighScoreUpdated", updatedImageDisplayTime);
            newFlag.gameObject.SetActive(true);
        }

        DisplayMedal();

        scoreText.SetActive(false);
        gameOver.SetActive(true);
        scoreBoard.SetActive(true);
        endModelScoreText.text = score.ToString();
        playButton.SetActive(true);
        menuButton.SetActive(true);
        resumeButton.SetActive(false);
        pauseButton.SetActive(false);
        highScoreText.text = highScore.ToString();

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.GetComponent<Text>().text = score.ToString();

        UpdateUI();
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey);
        }
    }

    private void ResetHighScoreUpdated()
    {
        highScoreUpdated = false;
        UpdateUI();
    }

    private void DisplayMedal()
    {
        if (score < 10)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
            platMedal.SetActive(false);
        } else if (score >= 10 && score < 20)
        {
            bronzeMedal.SetActive(true);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
            platMedal.SetActive(false);
        } else if (score >= 20 && score < 30)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(true);
            goldMedal.SetActive(false);
            platMedal.SetActive(false);
        } else if (score >= 30 && score < 40)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(true);
            platMedal.SetActive(false);
        } else if (score >= 40)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
            platMedal.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        resumeButton.SetActive(true);
        menuButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}
