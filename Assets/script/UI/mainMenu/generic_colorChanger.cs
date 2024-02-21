using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generic_colorChanger : MonoBehaviour
{
    /*
     * Generic Color Changer
     * Just what it says on the tin can. It changes
     * the color of the sprite and/or image if it's
     * a UI element.
     */

    public Color[] colors;
    [SerializeField] private Image img;
    [SerializeField] private SpriteRenderer sprr;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        sprr = GetComponent<SpriteRenderer>();
    }

    public void changeImageColor(int specifiedColorFromArray)
    {
        if(img != null)
        {
            img.color = colors[specifiedColorFromArray];
        }
        if (sprr != null)
        {
            sprr.color = colors[specifiedColorFromArray];
        }
    }
}
