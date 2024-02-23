using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class healthSafetyDebugEnter : MonoBehaviour
{
    private PlayerInput pl_input;

    // Start is called before the first frame update
    void Start()
    {
        pl_input = GetComponent<PlayerInput>();
    }

    void OnEnterDebugMenu()
    {
        SceneManager.LoadScene("masterDebugStandalone");
    }
}
