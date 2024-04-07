using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class stopControllerVibration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Gamepad.current != null)
        {
            InputSystem.PauseHaptics();
        }
    }
}
