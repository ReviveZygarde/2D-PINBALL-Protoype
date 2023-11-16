using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/*
 * for solely testing the Rhythm Mode test scene.
 * 
 */

public class gameplayControlsBehavior_forRH : MonoBehaviour
{

    public bool lfIsHeld;
    public bool rfIsHeld;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnLeftFlipper(InputValue value)
    {
        lfIsHeld = value.isPressed;
    }

    void OnRightFlipper(InputValue value)
    {
        rfIsHeld = value.isPressed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
