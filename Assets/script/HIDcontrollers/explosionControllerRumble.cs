using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class explosionControllerRumble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(Gamepad.current != null)
        {
            StartCoroutine(rumbleEffect());
        }
    }

    IEnumerator rumbleEffect()
    {
        Gamepad.current.SetMotorSpeeds(1f, 1f);
        yield return new WaitForSecondsRealtime(0.75f);
        InputSystem.PauseHaptics();
        yield return null;
    }
}
