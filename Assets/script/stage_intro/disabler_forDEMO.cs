using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disabler_forDEMO : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToEnableInPlace;

    void Start()
    {
        switch (globalSetting.Instance.buildType)
        {
            case globalSetting.releaseLevel.RELEASE:
                break;
            case globalSetting.releaseLevel.DEMO:
                if(objectToEnableInPlace != null)
                {
                    objectToEnableInPlace.SetActive(true);
                }
                this.gameObject.SetActive(false);
                break;
            case globalSetting.releaseLevel.DEVELOP:
                break;
        }
    }
}
