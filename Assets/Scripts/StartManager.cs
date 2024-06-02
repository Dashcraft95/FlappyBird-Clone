using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject logo;
    public GameObject bird;
    public GameObject instructions;
    public GameObject okButton;
    public GameObject closeScoreButton;
    public GameObject scoreButton;
    public GameObject player;
    public GameObject getReady;
    public GameObject menuScoreBoard;
    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;
    public GameObject platMedal;

    public Text highScoreText;
    public int score;
    public int highScore;

    // PlayerPref Keys
    private const string HighScoreKey = "HighScore";
    private void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey);
        }
    }

    private void UpdateUI()
    {
        highScoreText.text = highScore.ToString();
    }

    private void Awake()
    {
        UpdateUI();
        LoadHighScore();
    }

    private void Start()
    {
        UpdateUI();
        LoadHighScore();
        startButton.SetActive(true);
        logo.SetActive(true);
        bird.SetActive(true);
        scoreButton.SetActive(true);
        instructions.SetActive(false);
        okButton.SetActive(false);
        player.SetActive(false);
        getReady.SetActive(false);

        menuScoreBoard.SetActive(false);
        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
        platMedal.SetActive(false);
        closeScoreButton.SetActive(false);
    }
   

    public void Play()
    {
        logo.SetActive(false);
        bird.SetActive(false);
        instructions.SetActive(true);
        okButton.SetActive(true);
        startButton.SetActive(false);
        scoreButton.SetActive(false);
        player.SetActive(true);
        getReady.SetActive(true);
    }

    public void MenuScoreBoard()
    {
        
        menuScoreBoard.SetActive(true);
        highScoreText.gameObject.SetActive(true);

        if (highScore < 10)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
            platMedal.SetActive(false);
        }
        else if (highScore >= 10 && highScore < 20)
        {
            bronzeMedal.SetActive(true);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
            platMedal.SetActive(false);
        }
        else if (highScore >= 20 && highScore < 30)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(true);
            goldMedal.SetActive(false);
            platMedal.SetActive(false);
        }
        else if (highScore >= 30 && highScore < 40)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(true);
            platMedal.SetActive(false);
        }
        else if (highScore >= 40)
        {
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
            platMedal.SetActive(true);
        }

        startButton.SetActive(false);
        scoreButton.SetActive(false);
        closeScoreButton.SetActive(true);
    }

    public void CloseScoreBoard()
    {
        menuScoreBoard.SetActive(false);
        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
        platMedal.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        closeScoreButton.SetActive(false);
        startButton.SetActive(true);
        scoreButton.SetActive(true);
    }
}
