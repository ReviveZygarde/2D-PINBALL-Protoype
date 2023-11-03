using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alphaEffectForImage : MonoBehaviour
{
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Color imgColor = image.color;
        if (imgColor.a > 0.5)
        {
            imgColor.a = imgColor.a - 0.1f;
        }
        if (imgColor.a < 128)
        {
            imgColor.a = imgColor.a + 0.1f;
        }
    }
}
