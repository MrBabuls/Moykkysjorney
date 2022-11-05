using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool Winner;
    public static int numberOffCoins;
    public GameObject gameOverScreen;
    public GameObject WinnerScreen;
    public GameObject pauseMenuScreen;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        isGameOver = false;
        Winner = false;
    }

    void Update()
    {
        coinsText.text = numberOffCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        else if (Winner)
        {
            WinnerScreen.SetActive(true);
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
