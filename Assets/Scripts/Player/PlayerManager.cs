using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static int numberOffCoins;
    public TextMeshProUGUI coinsText;
    public GameObject pauseMenuScreen;

    private void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        coinsText.text = numberOffCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
