using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    [SerializeField] GameObject KisakiBall;

    void Awake()
    {
        instance = this; 
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        // Instiate(Ball);
    }
}
