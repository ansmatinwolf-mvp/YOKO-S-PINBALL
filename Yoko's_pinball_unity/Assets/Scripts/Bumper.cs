using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bumper : MonoBehaviour
{
    [SerializeField] private new Light light;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private int points = 150;

    private float timeLeftLightShine;

    void Update()
    {
        if (timeLeftLightShine > 0)
        {
            timeLeftLightShine -= Time.deltaTime;

            if (timeLeftLightShine < 0)
            {
                light.enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddExplosionForce(30f, transform.position, 8f, 0f, ForceMode.Impulse);

            if (hitSound != null)
            {
                hitSound.Play();
            }

            Game.Instance.IncreaseScore(points);

            light.enabled = true;
            timeLeftLightShine = 0.2f;
        }
    }
}