using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introStartPrompt : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(flashPrompt());
    }

    IEnumerator flashPrompt()
    {
        while (this.isActiveAndEnabled)
        {
            image.enabled = false;
            yield return new WaitForSeconds(0.5f);
            image.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
