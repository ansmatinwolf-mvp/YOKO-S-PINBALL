using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // prevent duplicates if this scene reloads
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
