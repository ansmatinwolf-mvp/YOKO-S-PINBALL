using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [Header("Trigger")]
    public int scoreThreshold = 6000;

    [Header("Boss")]
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    bool bossSpawned = false;

    void Update()
    {
        if (bossSpawned) return;

        if (Game.Instance == null) return;

        int currentScore = Game.Instance.GetScore();

        if (currentScore >= scoreThreshold)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        bossSpawned = true;

        if (bossPrefab != null && bossSpawnPoint != null)
        {
            Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
            Debug.Log("Boss spawned!");
        }
        else
        {
            Debug.LogWarning("BossSpawner: missing bossPrefab or bossSpawnPoint reference.");
        }
    }
}