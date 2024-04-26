using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleEffects : MonoBehaviour
{
    public AudioSource vo;
    public void toggleEffectsSetting()
    {
        if(globalSetting.Instance.postprocessEffectsEnabled)
        {
            globalSetting.Instance.postprocessEffectsEnabled = false;
            vo.Play();
        }
        else
        {
            globalSetting.Instance.postprocessEffectsEnabled = true;
        }
    }
}
