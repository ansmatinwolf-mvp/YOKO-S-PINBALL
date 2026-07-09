using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameOverUI gameOverUI;
    private int currentHealth;

    public event Action<int, int> OnHealthChanged; // (current hp, max hp) - UI here later
    public event Action OnGameOver;

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
            GameOver();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        OnGameOver?.Invoke();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;

    //Test key for taking damage.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
}