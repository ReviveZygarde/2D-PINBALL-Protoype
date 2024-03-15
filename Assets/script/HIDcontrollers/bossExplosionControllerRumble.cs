using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bossExplosionControllerRumble : MonoBehaviour
{
    void OnEnable()
    {
        if(Gamepad.current != null)
        {
            StartCoroutine(rumbleEffect());
        }
    }

    IEnumerator rumbleEffect()
    {
        Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
        yield return new WaitForSecondsRealtime(5f);
        Gamepad.current.PauseHaptics();
        Gamepad.current.SetMotorSpeeds(1f, 1f);
        yield return new WaitForSecondsRealtime(0.5f);
        Gamepad.current.PauseHaptics();
        yield return null;
    }
}
