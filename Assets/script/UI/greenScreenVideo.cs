using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class greenScreenVideo : MonoBehaviour
{
    private VideoPlayer videoComponent;
    private SpriteRenderer spriteRenderer;

    /*
     * When using Greenscreen videos in gameplay, be sure to attach this script to it.
     * You will probably need this because you do not want a 1-2 frame flashbang of a
     * sprite color filling the entire screen, which is also lowkey epileptic.
     * This is because of how Material Overrides work with the Video Player, and
     * due to how the greenscreen shader is made, preventing the "flashbang" is
     * done by code.
     */

    // Start is called before the first frame update
    void Start()
    {
        videoComponent = GetComponent<VideoPlayer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoComponent.isPlaying)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
