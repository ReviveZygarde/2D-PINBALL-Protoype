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

        switch (globalSetting.Instance.buildType)
        {
            case globalSetting.releaseLevel.RELEASE:
                this.gameObject.SetActive(false);
                break;
            case globalSetting.releaseLevel.DEMO:
                break;
            case globalSetting.releaseLevel.DEVELOP:
                break;
        }
    }

    void OnEnterDebugMenu()
    {
        SceneManager.LoadScene("masterDebugStandalone");
    }
}
