using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToPlayScene()
    {
        SceneManager.LoadScene("Flappy Bird");
    }

    public void SwitchToStartScene()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
}
