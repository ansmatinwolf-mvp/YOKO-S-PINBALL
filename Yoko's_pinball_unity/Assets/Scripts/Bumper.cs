
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bumper : MonoBehaviour
{
    [SerializeField] private new Light light;
    private float timeLeftLightShine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( timeLeftLightShine > 0)
        {
            timeLeftLightShine -= Time.deltaTime;
            if(timeLeftLightShine < 0)
            {
                light.enabled = false; 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.GetComponent<Rigidbody>().AddExplosionForce(7000f, transform.position, 8);
        light.enabled = true;
        timeLeftLightShine = 0.2f;
    }
}
