using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class JumperControllerRumble : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Gamepad.current != null)
        {
            StartCoroutine(rumbleEffect());
        }
    }

    IEnumerator rumbleEffect()
    {
        Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
        yield return new WaitForSecondsRealtime(0.05f);
        InputSystem.PauseHaptics();
        yield return null;
    }
}
