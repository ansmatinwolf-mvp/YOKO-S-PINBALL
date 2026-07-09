using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] float hitStrength = 200000f; //80000 if too high. Higher value makes flipper snap up faster and harder 
    [SerializeField] float dampening = 100f; //250 original dampening. Higher value = slower movement of hinges
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;

    JointSpring leftReleased;
    JointSpring leftPressed;
    JointSpring rightReleased;
    JointSpring rightPressed;

    void Start()
    {
        hingeJointLeft.useSpring = true;
        hingeJointRight.useSpring = true;

        leftPressed.spring = hitStrength;
        leftPressed.damper = dampening;
        leftPressed.targetPosition = hingeJointLeft.limits.max;

        leftReleased.spring = hitStrength;
        leftReleased.damper = dampening;
        leftReleased.targetPosition = hingeJointLeft.limits.min;

        rightPressed.spring = hitStrength;
        rightPressed.damper = dampening;
        rightPressed.targetPosition = hingeJointRight.limits.min;

        rightReleased.spring = hitStrength;
        rightReleased.damper = dampening;
        rightReleased.targetPosition = hingeJointRight.limits.max;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            hingeJointLeft.spring = leftPressed;
        else
            hingeJointLeft.spring = leftReleased;

        if (Input.GetKey(KeyCode.RightShift))
            hingeJointRight.spring = rightPressed;
        else
            hingeJointRight.spring = rightReleased;
    }
}