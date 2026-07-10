using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Game : MonoBehaviour
{
    [SerializeField] AudioSource soundPoints;
    private Vector3 startPosition = new Vector3(27.3299999f, -5.30000019f, 0.189999998f);
    public static Game Instance;
    [SerializeField] GameObject pfBall;
    [SerializeField] TextMeshProUGUI textScore;
    private int score;
    public GameObject PfBall { get => pfBall; set => pfBall = value; }
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Physics.gravity = new Vector3(0, -50, 0);
        SpawnBall();
        UpdateScoreText();
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        if (soundPoints != null)
        {
            soundPoints.Play();
        }
    }
    private void UpdateScoreText()
    {
        if (textScore != null)
        {
            textScore.text = score.ToString("00000000");
        }
    }
    public void SpawnBall()
    {
        Instantiate(pfBall, startPosition, Quaternion.identity);
    }

    public int GetScore()
    {
        return score;
    }
}