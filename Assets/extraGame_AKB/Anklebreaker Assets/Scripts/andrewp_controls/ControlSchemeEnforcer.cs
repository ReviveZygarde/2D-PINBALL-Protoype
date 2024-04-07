using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.XR;

public class ControlSchemeEnforcer : MonoBehaviour
{
    //Feel free to disable this Component via inspector in case you need to test using the Keyboard.

    public PlayerInput player1Input;
    public PlayerInput player2Input;
    private bool p1UsingXInput;
    // Start is called before the first frame update
    void Start()
    {
        //EnforceSchemes();
    }

    private void Update()
    {
        EnforceSchemes();
    }

    private void EnforceSchemes()
    {
        if (!player1Input.enabled || !player2Input.enabled)
        {
            return; //so null user errors aren't sharted out when you guard or shoot.
        }
        if (InputSystem.GetDevice("XInputControllerWindows") != null)
        {
            player1Input.SwitchCurrentControlScheme("Gamepad", InputSystem.GetDevice("XInputControllerWindows"));
            p1UsingXInput = true;
        }
        if (p1UsingXInput)
        {
            if (InputSystem.GetDevice("XInputControllerWindows1") != null)
            {
                player2Input.SwitchCurrentControlScheme("Gamepad", InputSystem.GetDevice("XInputControllerWindows1"));
            }
            else
            {
                if (InputSystem.GetDevice("DualShock4GamepadHID") != null)
                {
                    player2Input.SwitchCurrentControlScheme("Gamepad", InputSystem.GetDevice("DualShock4GamepadHID"));
                }
                return;
            }
            return;
        }
        return;
    }
}
