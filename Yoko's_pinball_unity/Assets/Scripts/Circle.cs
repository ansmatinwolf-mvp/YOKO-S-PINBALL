using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float lightValue;
    private new Light light;
    [SerializeField] AudioSource soundCircle;

    [SerializeField] private float maxLightValue = 6f;
    [SerializeField] private float fadeSpeed = 1000f;
    [SerializeField] private int scoreAmount = 300;

    void Start()
    {
        light = GetComponent<Light>();

        if (light != null)
        {
            light.intensity = 0f;
            lightValue = 0f;
        }
    }

    void Update()
    {
        if (light != null)
        {
            light.intensity = Mathf.MoveTowards(
                light.intensity,
                lightValue,
                fadeSpeed * Time.deltaTime
            );

            if (light.intensity >= maxLightValue)
            {
                lightValue = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (soundCircle != null)
            {
                soundCircle.Play();
            }

            if (Game.Instance != null)
            {
                Game.Instance.IncreaseScore(scoreAmount);
            }

            lightValue = maxLightValue;
        }
    }
}