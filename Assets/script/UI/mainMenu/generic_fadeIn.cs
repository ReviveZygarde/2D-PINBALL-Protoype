using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class generic_fadeIn : MonoBehaviour
{
    private Image image;

    // Start is called before the first frame update
    void OnEnable()
    {
        image = GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0);
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // loop over 1 second
        for (float i = 0; i <= 1.05; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
    }
}
