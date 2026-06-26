using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : MonoBehaviour
{
    [SerializeField] Transform.spawnPosition1, spawnPosition2;

        private void OnCollisionEnter(Collision collision)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length < 3)
        {
            Instantiate(GameObject.Instance.PfBall, spawnPosition1.position, Quaternion.identity);
            Instantiate(GameObject.Instance.PfBall, spawnPosition2.position, Quaternion.identity);
        }
        collision.collider.GetComponent<Rigidbody>().AddExplosionForce(4000f, transform.position, 8);
    }
}
