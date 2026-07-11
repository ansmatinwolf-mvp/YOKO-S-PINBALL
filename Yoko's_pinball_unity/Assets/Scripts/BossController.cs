using UnityEngine;

public class BossController : EnemyShooter
{
    [Header("Boss Health")]
    public int maxHealth = 100;
    protected int currentHealth;

    [Header("Boss Phases")]
    [Tooltip("Health % (0-1) at which phase 2 starts (faster fire, ignores detection range)")]
    public float phase2HealthThreshold = 0.5f;
    protected int currentPhase = 1;

    [Header("Phase 2 Overrides")]
    public float phase2FireRateMultiplier = 2f;

    [Header("Burst Attack")]
    public int burstShotCount = 3;
    public float burstShotDelay = 0.15f;
    protected bool isBursting = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    protected override void Update()
    {
        // Reuse all the base aiming/detection/shooting logic
        base.Update();

        CheckPhaseTransition();
    }

    protected override bool CanSeePlayer()
    {
        // Phase 2: boss always "sees" the player, ignoring range/line of sight
        if (currentPhase >= 2) return player != null;

        return base.CanSeePlayer();
    }

    protected override void Shoot()
    {
        if (isBursting) return;

        if (currentPhase >= 2)
            StartCoroutine(BurstFire());
        else
            base.Shoot(); // normal single shot, same as regular enemies
    }

    System.Collections.IEnumerator BurstFire()
    {
        isBursting = true;
        for (int i = 0; i < burstShotCount; i++)
        {
            base.Shoot();
            yield return new WaitForSeconds(burstShotDelay);
        }
        isBursting = false;
    }

    void CheckPhaseTransition()
    {
        if (currentPhase == 1 && currentHealth <= maxHealth * phase2HealthThreshold)
        {
            currentPhase = 2;
            fireRate *= phase2FireRateMultiplier;
            Debug.Log(gameObject.name + " entered Phase 2!");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " defeated!");
        Destroy(gameObject);
    }
}