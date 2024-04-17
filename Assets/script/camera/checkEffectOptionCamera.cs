using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class checkEffectOptionCamera : MonoBehaviour
{
    PostProcessLayer postProcess;

    // Start is called before the first frame update
    void Start()
    {
        postProcess = GetComponent<PostProcessLayer>();
        if(globalSetting.Instance.postprocessEffectsEnabled == false)
        {
            postProcess.enabled = false;
        }
    }
}
