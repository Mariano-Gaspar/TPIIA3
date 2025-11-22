// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timePlayedText;
    [SerializeField] private string mainMenuScene = "MenuScene";


    private void OnEnable()
    {
        timePlayedText.text = PlayerStats.gamePlayingTime.ToString("0:00.0");
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
