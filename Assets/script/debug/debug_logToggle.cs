using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug_logToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(globalSetting.Instance.buildType == globalSetting.releaseLevel.RELEASE || globalSetting.Instance.buildType == globalSetting.releaseLevel.DEMO)
        {
            Debug.Log("This is RELEASE or DEMO. Debug logging will be OFF.");
            Debug.unityLogger.logEnabled = false;
        }
        else
        {
            Debug.Log("This is DEVELOP. Debug logging will be ON.");
            Debug.unityLogger.logEnabled = true;
        }
    }
}
