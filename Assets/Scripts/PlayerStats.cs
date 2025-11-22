// MARIANO CODUTTI ALARCON
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int startMoney = 100;
    public static int money;

    [SerializeField] private int startHealth = 20;
    public static int playerHealth;

    public static int waves;
    public static float gamePlayingTime;


    private void Start()
    {
        money = startMoney;
        playerHealth = startHealth;
        waves = 0;
    }

    private void Update()
    {
        gamePlayingTime += Time.deltaTime;
    }


    public int GetStartHealth()
    {
        return startHealth;
    }
}
