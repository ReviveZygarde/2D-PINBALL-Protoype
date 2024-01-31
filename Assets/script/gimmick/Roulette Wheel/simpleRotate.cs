using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleRotate : MonoBehaviour
{
    public float speed;
    public float originalSpeed;

    private void Start()
    {
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
    }
}
