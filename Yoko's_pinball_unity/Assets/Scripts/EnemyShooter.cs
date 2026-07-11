using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Detection")]
    public float detectionRange = 15f;
    public LayerMask lineOfSightMask = ~0;

    [Header("Aiming")]
    public float rotationSpeed = 5f;

    [Header("Firing")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    protected float fireCooldown;

    protected virtual void Update()
    {
        if (player == null) return;

        if (CanSeePlayer())
        {
            AimAtPlayer();
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }
    }

    protected virtual bool CanSeePlayer()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > detectionRange) return false;

        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        if (Physics.Raycast(transform.position, dirToPlayer, out RaycastHit hit, detectionRange, lineOfSightMask))
        {
            return hit.transform == player;
        }
        return false;
    }

    protected virtual void AimAtPlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        dir.y = 0f;
        if (dir == Vector3.zero) return;

        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
    }

    protected virtual void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        if (firePoint != null)
        {
            Gizmos.color = Color.yellow;
            Vector3 start = firePoint.position;
            Vector3 end = start + firePoint.forward * 2f;
            Gizmos.DrawLine(start, end);

            Vector3 right = Quaternion.LookRotation(firePoint.forward) * Quaternion.Euler(0, 160, 0) * Vector3.forward;
            Vector3 left = Quaternion.LookRotation(firePoint.forward) * Quaternion.Euler(0, -160, 0) * Vector3.forward;
            Gizmos.DrawLine(end, end + right * 0.3f);
            Gizmos.DrawLine(end, end + left * 0.3f);
        }
    }
}