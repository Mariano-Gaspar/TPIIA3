// MARIANO CODUTTI ALARCON
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Unity Setup Stuff")]
    [SerializeField] private Transform rotationPivot;
    [SerializeField] private Image healthBar;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int deathValue = 20;
    [SerializeField] private int damageToBase = 1;

    [SerializeField] private float baseEnemyHealth = 100;
    private float enemyHealth;


    private Transform waypointTarget;
    private int waypointIndex = 0;
    private bool isDead = false;


    private void Start()
    {
        waypointTarget = Waypoints.points[0];
        enemyHealth = baseEnemyHealth;
    }

    private void Update()
    {
        // Move to next waypoint.
        Vector3 moveDirection = waypointTarget.position - transform.position;
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Turn.
        if (moveDirection != Vector3.zero && rotationPivot != null)
        {
            float turnSmooth = 20f;
            rotationPivot.forward = Vector3.Lerp(rotationPivot.forward, moveDirection, Time.deltaTime * turnSmooth);
        }

        // Get next waypoint.
        if (Vector3.Distance(transform.position, waypointTarget.position) <= .2f)
        {
            GetNextWaypoint();
        }
    }


    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        waypointTarget = Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.playerHealth -= damageToBase;

        BaseUI baseUI = FindAnyObjectByType<BaseUI>();
        baseUI.UpdateHealthBar();

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }

    public void TakeDamage(float _damageAmount)
    {
        enemyHealth -= _damageAmount;

        healthBar.fillAmount = enemyHealth / baseEnemyHealth;

        if (enemyHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.money += deathValue;
        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}
