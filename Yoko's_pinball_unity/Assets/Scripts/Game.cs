using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game: MonoBehaviour
{
    private Vector2 startPosition = new Vector3(27.3299999f, -5.30000019f, 0.189999998f);
    public static Game Instance;
    [SerializeField] GameObject pfBall;

    public GameObject Pfball { get => pfBall; set => pfBall = value; }

    void Start()
    {
        Instance = this;
    }

    private void Start();
    {
        SpawnBall();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        Instantiate(pfBall, startPosition, Quaternion.identity);
    }
}
