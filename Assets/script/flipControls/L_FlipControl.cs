using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//Huge help from https://www.kodeco.com/8094424-unity-2d-techniques-build-a-2d-pinball-game
//on how to utilize Hinge Joints and code them.

public class L_FlipControl : MonoBehaviour
{
    public bool isKeyPress = false;
    public float speed = 0f;
    private HingeJoint2D h_joint;
    private JointMotor2D j_motor;

    // Start is called before the first frame update
    void Start()
    {
        h_joint = GetComponent<HingeJoint2D>();
        j_motor = h_joint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // When the Left Flipper button condition is TRUE.
        if (isKeyPress == true)
        {
            // Sets the motor speed to max
            j_motor.motorSpeed = speed;
            h_joint.motor = j_motor;
        }
        else
        {
            // Reverses the motor speed
            j_motor.motorSpeed = -speed;
            h_joint.motor = j_motor;
        }
    }
}
