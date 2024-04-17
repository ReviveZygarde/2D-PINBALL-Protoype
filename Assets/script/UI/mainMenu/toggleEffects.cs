using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleEffects : MonoBehaviour
{
    public void toggleEffectsSetting()
    {
        if(globalSetting.Instance.postprocessEffectsEnabled)
        {
            globalSetting.Instance.postprocessEffectsEnabled = false;
        }
        else
        {
            globalSetting.Instance.postprocessEffectsEnabled = true;
        }
    }
}
