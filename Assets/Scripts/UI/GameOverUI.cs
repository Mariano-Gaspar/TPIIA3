// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text wavesAmountText;
    [SerializeField] private string mainMenuScene = "MenuScene";


    private void OnEnable()
    {
        wavesAmountText.text = PlayerStats.waves.ToString();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }
}
