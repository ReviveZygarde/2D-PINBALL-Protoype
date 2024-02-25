using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildTypeChanger : MonoBehaviour
{
    public void changeReleaseLevel()
    {
        switch (globalSetting.Instance.buildType)
        {
            case globalSetting.releaseLevel.RELEASE:
                globalSetting.Instance.buildType = globalSetting.releaseLevel.DEMO;
                break;
            case globalSetting.releaseLevel.DEMO:
                globalSetting.Instance.buildType = globalSetting.releaseLevel.DEVELOP;
                break;
            case globalSetting.releaseLevel.DEVELOP:
                globalSetting.Instance.buildType = globalSetting.releaseLevel.RELEASE;
                break;
        }
    }
}
