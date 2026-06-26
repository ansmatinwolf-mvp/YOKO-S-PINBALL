using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
 
    void Onshoot()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.5f);

        foreach (Collider collider in colliders)
        {
            Ball ball = collider.GetComponent<Ball>();
            if (ball != null)
            {
                collider.GetComponent<Ball>().Shoot();
            }
        }
    }
}
