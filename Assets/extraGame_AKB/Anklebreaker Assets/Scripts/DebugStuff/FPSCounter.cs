using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    float pollingTime = 1;
    float time;
    float frameCount;

    // Start is called before the first frame update
    void Start()
    {
        FpsText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if (time >= pollingTime) 
        {
            int FrameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = "FPS:" + FrameRate.ToString();
            time -= pollingTime;
            frameCount = 0;
        }


    }
}
