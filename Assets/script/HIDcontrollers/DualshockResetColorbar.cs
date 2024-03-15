using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class DualshockResetColorbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (DualShockGamepad.current != null)
        {
            DualShockGamepad.current.SetLightBarColor(Color.black);
        }
    }
}
