// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    [SerializeField] private GameObject creditsMenu;


    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditsMenu.SetActive(true);
    }

    public void HideCredits()
    {
        creditsMenu.SetActive(false);
    }
}
