// MARIANO CODUTTI ALARCON
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private string enemyTag = "Enemy";
    private Transform enemyTarget;

    [SerializeField] private Transform rotationPivot;
    [SerializeField] private Transform firePoint;


    [Header("Attributes")]
    [SerializeField] private float range = 3f;
    [SerializeField] private float fireRate = 1f;
    private float timeToShoot = .2f;


    private void Start()
    {
        float startTime = 0f;
        float frequency = .5f;
        InvokeRepeating("UpdateTarget", startTime, frequency);
    }

    private void Update()
    {
        if (enemyTarget == null)
            return;

        LockOnTarget();

        if (timeToShoot <= 0f)
        {
            Shoot();
            timeToShoot = 1f / fireRate;
        }

        timeToShoot -= Time.deltaTime;
    }


    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Find nearest enemy in range.
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // Set enemy target.
        if (nearestEnemy != null && shortestDistance <= range)
        {
            enemyTarget = nearestEnemy.transform;
        }
        else
        {
            enemyTarget = null;
        }
    }

    private void LockOnTarget()
    {
        Vector3 lookDirection = enemyTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        float turnSmoothness = 10f;
        Vector3 rotateDirection = Quaternion.Lerp(rotationPivot.rotation, lookRotation, Time.deltaTime * turnSmoothness).eulerAngles;
        rotationPivot.rotation = Quaternion.Euler(0f, rotateDirection.y, 0f);
    }

    private void Shoot()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.SeekTarget(enemyTarget);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
