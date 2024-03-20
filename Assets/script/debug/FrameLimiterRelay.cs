using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameLimiterRelay : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(globalSetting.Instance.frameRateLimitTo60FPS == true)
        {
            text.text = "ON (60FPS)";
        }
        else
        {
            text.text = "OFF (UNLOCKED)";
        }
    }
}
