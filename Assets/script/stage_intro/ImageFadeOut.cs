using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    private Image img;

    void OnEnable()
    {
        img = GetComponent<Image>();
        //img.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeImage());
    }


    IEnumerator FadeImage() //image fade-in and out code is from https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(img.color.r, img.color.g, img.color.b, i);
            yield return null;
        }
    }
}