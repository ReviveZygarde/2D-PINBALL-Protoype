using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
//https://forum.unity.com/threads/cant-access-cinemachine-via-c.525753/ found access
public class CamerCloseAndFar : MonoBehaviour
{
    public GameObject camera_far;
    public GameObject camera_close;

    public bool camera_toogle_on = true;

    // Start is called before the first frame update
    void Start()
    {
        camera_close = GameObject.FindGameObjectWithTag("camera_close");
        camera_far = GameObject.FindGameObjectWithTag("camera_far");
        Switch_Cameras(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch_Cameras(bool camy)
    {
        if (camera_toogle_on == true)
        {
            if (camy == false)
            {
                Closeup();
            }
            else
            {
                FarOut();
            }
        }
        else
        {
            FarOut();
        }

    }

    void Closeup()
    {
        camera_close.SetActive(true);
        camera_far.SetActive(false);
    }

    void FarOut()
    {
        camera_far.SetActive(true);
        camera_close.SetActive(false);
    }

}
