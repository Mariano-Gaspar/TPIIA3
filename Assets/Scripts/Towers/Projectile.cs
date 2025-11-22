// MARIANO CODUTTI ALARCON
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float explosionRadius = 0f;
    [SerializeField] private float damageToEnemy = 1f;

    private Transform enemyTarget;


    private void Update()
    {
        if (enemyTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = enemyTarget.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(enemyTarget);
    }


    public void SeekTarget(Transform _target)
    {
        enemyTarget = _target;
    }

    private void HitTarget()
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DamageTarget(enemyTarget);
        }

        Destroy(gameObject);
    }

    private void DamageTarget(Transform _target)
    {
        Enemy target = _target.GetComponent<Enemy>();

        if (target != null)
        {
            target.TakeDamage(damageToEnemy);
        }
    }

    private void Explode()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider target in targets)
        {
            if (target.tag == "Enemy")
            {
                DamageTarget(target.transform);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
