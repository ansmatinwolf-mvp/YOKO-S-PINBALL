using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 previousPosition;
    private new Rigidbody rigidbody;
    private Vector3 startPosition = new Vector3(2.9000001f, -11.0600004f, -3.70000005f);


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rigidbody.AddForce(new Vector3(0, 40, 0), ForceMode.VelocityChange);
    }


    void Update()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 speed = position - previousPosition;
        Vector2 rotationAxis = Vector2.Perpendicular(speed);
        transform.Rotate(new Vector3(rotationAxis.x, rotationAxis.y, 0), -speed.magnitude * 40f, Space.World);
        previousPosition = position;
        if (transform.position.y < -15)
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }

}
