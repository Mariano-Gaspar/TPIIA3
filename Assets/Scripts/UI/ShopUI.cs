// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TowerBlueprint towerBallista;
    [SerializeField] private TowerBlueprint towerCannon;

    [SerializeField] private Button ballistaButton;
    [SerializeField] private Button canonButton;

    private BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        if (PlayerStats.money < towerBallista.cost)
        {
            ballistaButton.interactable = false;
        }
        else
        {
            ballistaButton.interactable = true;
        }

        if (PlayerStats.money < towerCannon.cost)
        {
            canonButton.interactable = false;
        }
        else
        {
            canonButton.interactable= true;
        }
    }


    public void SelectTowerBallista()
    {
        // Debug.Log("Ballista selected");
        buildManager.SelectTowerToBuild(towerBallista);
    }

    public void SelectTowerCannon()
    {
        // Debug.Log("Cannon selected");
        buildManager.SelectTowerToBuild(towerCannon);
    }
}
