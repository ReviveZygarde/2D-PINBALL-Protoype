using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleRotate : MonoBehaviour
{
    public float speed;
    private float fallbackSpeed = -50f;
    public float originalSpeed;

    private void Start()
    {
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed > -20)
        {
            transform.Rotate(0, 0, Time.deltaTime * fallbackSpeed, Space.Self);
        }
        else
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
    }
}
