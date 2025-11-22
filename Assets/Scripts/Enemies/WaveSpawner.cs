// MARIANO CODUTTI ALARCON
using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private WaveData[] waves;
    private int waveIndex = 0;

    [SerializeField] private float timeToSpawnNextWave = 5f;
    private float waveTimer = 3f;

    public static int enemiesAlive;

    [SerializeField] private TMP_Text waveCountdownText;


    private void Start()
    {
        enemiesAlive = 0;
    }

    private void Update()
    {
        if (enemiesAlive > 0)
            return;

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (waveTimer <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveTimer = timeToSpawnNextWave;
            return;
        }

        waveTimer -= Time.deltaTime;
        waveTimer = Mathf.Clamp(waveTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next wave in... " + string.Format("{0:00.00}", waveTimer) + "s";
    }


    private IEnumerator SpawnWave()
    {
        PlayerStats.waves++;

        WaveData currentWave = waves[waveIndex];
        enemiesAlive = currentWave.enemiesCount;

        for (int i = 0; i < currentWave.enemiesCount; i++)
        {
            SpawnEnemy(currentWave.enemyPrefab);
            yield return new WaitForSeconds(1f / currentWave.spawnRate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
    }


    public int GetWavesAmount()
    {
        return waves.Length;
    }
}
