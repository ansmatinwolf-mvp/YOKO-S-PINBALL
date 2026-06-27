using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] float hitStrength = 80000f;
    [SerializeField] float dampening = 250f;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;

    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();

    void Start()
    {
        jointSpringPressed.spring = jointSpringReleased.spring = hitStrength;
        jointSpringPressed.damper = jointSpringReleased.damper = dampening;
        jointSpringPressed.targetPosition = hingeJointLeft.limits.max;
        jointSpringReleased.targetPosition = hingeJointLeft.limits.min;
    }

    void Update()
    {
        // Left flipper
        if (Input.GetKey(KeyCode.LeftShift))
            hingeJointLeft.spring = jointSpringPressed;
        else
            hingeJointLeft.spring = jointSpringReleased;

        // Right flipper — fixed to use hingeJointRight
        if (Input.GetKey(KeyCode.RightShift))
            hingeJointRight.spring = jointSpringPressed;
        else
            hingeJointRight.spring = jointSpringReleased;
    }
}

/* 
Please take a look at the old code here 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [SerializeField] float hitStrength = 80000f;
    [SerializeField] float dampening = 250f;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;
    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();
    private bool leftFlipperPressed, rightFlipperPressed;

    // Start is called before the first frame update
    void Start()
    {
        jointSpringPressed.spring = jointSpringReleased.spring = hitStrength;
        jointSpringPressed.damper = jointSpringReleased.damper = dampening;
        jointSpringPressed.targetPosition = hingeJointLeft.limits.max;
        jointSpringReleased.targetPosition = hingeJointLeft.limits.min;
    }

    private void OnLeftFlipper(InputValue value)
    {
        leftFlipperPressed = value.isPressed;
    }
    private void OnRightFlipper(InputValue value)
    {
        rightFlipperPressed = value.isPressed;
    }


    // Update is called once per frame
    void Update()
    {
        if (leftFlipperPressed)
        {
            hingeJointLeft.spring = jointSpringPressed;
        }
        else
        {
            hingeJointLeft.spring = jointSpringReleased;
        }
        if (rightFlipperPressed)
        {
            hingeJointLeft.spring = jointSpringPressed;
        }
        else
        {
            hingeJointLeft.spring = jointSpringReleased;
        }

    }
}
*/