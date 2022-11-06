using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;

    public TextMeshProUGUI timerText;
    public PlayerManager playerManager;

   public void Start()
    {
        timerOn = true;
    }

    public void FixedUpdate()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                playerManager.gameOverScreen.SetActive(true);
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

}
