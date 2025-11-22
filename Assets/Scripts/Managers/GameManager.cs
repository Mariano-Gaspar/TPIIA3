// MARIANO CODUTTI ALARCON
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject levelCompleteUI;

    public static bool gameIsOver;


    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.playerHealth <= 0)
        {
            EndGame();
        }
    }


    private void EndGame()
    {
        gameIsOver = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        Time.timeScale = 0f;
        levelCompleteUI.SetActive(true);
    }
}
