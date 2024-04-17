using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class reduceGlobalPostprocessEffect : reduceGlobalBloom
{
    PostProcessVolume volume;
    float originalWeight;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        originalWeight = volume.weight;
    }

    private void OnEnable()
    {
        volume.weight = originalWeight;
        StartCoroutine(reduceOtherEffect());
    }

    IEnumerator reduceOtherEffect()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            volume.weight = i;
            yield return null;
        }
        yield return null;
    }
}
