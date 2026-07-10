using System;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 500;
    [SerializeField] private VictoryUI victoryUI;
    private int currentHealth;

    public event Action<int, int> OnHealthChanged; // (current hp, max hp) - for a boss health bar
    public event Action OnBossDefeated;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        Debug.Log("Boss defeated!");
        OnBossDefeated?.Invoke();

        if (victoryUI != null)
        {
            victoryUI.ShowVictory();
        }

        // Optional: remove the boss from the scene after a short delay
        // Destroy(gameObject, 1f);
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}
