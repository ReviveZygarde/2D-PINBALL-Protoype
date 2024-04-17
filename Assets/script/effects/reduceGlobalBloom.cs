using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class reduceGlobalBloom : MonoBehaviour
{
    private PostProcessVolume volume;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.weight = 1.0f;
        StartCoroutine(reduceBloom());
    }

    IEnumerator reduceBloom()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            volume.weight = i;
            yield return null;
        }
    }
}
