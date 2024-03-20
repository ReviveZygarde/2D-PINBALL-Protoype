using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameLimiterEnforcer : MonoBehaviour
{
    globalSetting setting;

    private void Start()
    {
        setting = globalSetting.Instance;
        if(setting.frameRateLimitTo60FPS == true)
        {
            Application.targetFrameRate = 60;
            Debug.Log("Target framerate is 60");
        }
    }
    public void LockAndUnlockFramerate()
    {
        if(setting.frameRateLimitTo60FPS == false)
        {
            setting.frameRateLimitTo60FPS = true;
            Application.targetFrameRate = 60;
        }
        else
        {
            setting.frameRateLimitTo60FPS = false;
            Application.targetFrameRate = -1;
        }
    }
}
