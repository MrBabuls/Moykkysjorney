using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool Winner;
    public static bool timerOn;
    public static int numberOffCoins;
    public GameObject gameOverScreen;
    public GameObject WinnerScreen;
    public GameObject pauseMenuScreen;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timerText;
    public PlayerCollision playerCollision;
    public float timeLeft;

    public void Awake()
    {
        isGameOver = false;
        Winner = false;
        timerOn = true;
    }

   public void Update()
    {
        coinsText.text = numberOffCoins.ToString();
        if (isGameOver)
        {
            timerText.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        else if (Winner)
        {
            WinnerScreen.SetActive(true);
        }

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                playerCollision.PlayerDeathEffect();
                AudioManager.instance.Play("PlayerDeath");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

    public void ReplayLevel()
    {
        numberOffCoins = 0;
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
