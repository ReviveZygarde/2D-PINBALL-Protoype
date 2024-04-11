using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textFadeOutEffect : MonoBehaviour
{
    private TextMeshProUGUI textObject;

    void OnEnable()
    {
        textObject = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() //image fade-in and out code is from https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            textObject.color = new Color(textObject.color.r, textObject.color.g, textObject.color.b, i);
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
