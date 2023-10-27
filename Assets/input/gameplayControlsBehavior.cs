using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/*
 * gameplayControlsBehavior is what handles the New Input System
 * and also tells the Left/Right flippers, the Plunger, and the
 * table shaking mechanism whether they should be activated
 * or not.
 */

public class gameplayControlsBehavior : MonoBehaviour
{
    private PlayerInput pl_input;
    private L_FlipControl leftFlipperJoint;
    private R_FlipControl rightFlipperJoint;
    public bool lfIsHeld;
    public bool rfIsHeld;
    public bool plungerActionIsHeld;

    // Start is called before the first frame update
    void Start()
    {
        pl_input = GetComponent<PlayerInput>();
        leftFlipperJoint = GameObject.Find("L_HingeJoint").GetComponent<L_FlipControl>();
        rightFlipperJoint = GameObject.Find("R_HingeJoint").GetComponent<R_FlipControl>();
    }

    void OnLeftFlipper(InputValue value)
    {
        lfIsHeld = value.isPressed;
    }

    void OnRightFlipper(InputValue value)
    {
        rfIsHeld = value.isPressed;
    }

    void OnPlungerPullAction(InputValue value)
    {
        plungerActionIsHeld = value.isPressed;
    }

    /*
    private void defaultLFlipper()
    {
        
    }

    private void defaultRFlipper()
    {
        
    }
    */

    void OnBoardShake_Up(InputValue value)
    {
        Debug.Log("Table shake UP!!");
    }

    void OnBoardShake_L(InputValue value)
    {
        Debug.Log("Table shake LEFT!!");
    }

    void OnBoardShake_R(InputValue value)
    {
        Debug.Log("Table shake RIGHT!!");
    }

    //Debug Inputs
    /*
    void OnDebug_Exit(InputValue value)
    {
        Debug.Log("Scene exit...");
        SceneManager.LoadScene(0);
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (lfIsHeld)
        {
            leftFlipperJoint.isKeyPress = true;
        }
        if (rfIsHeld)
        {
            rightFlipperJoint.isKeyPress = true;
        }
        if (!lfIsHeld)
        {
            //defaultLFlipper();
            leftFlipperJoint.isKeyPress = false;
        }
        if (!rfIsHeld)
        {
            //defaultRFlipper();
            rightFlipperJoint.isKeyPress = false;
        }
    }
}
