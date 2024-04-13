using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPinball : MonoBehaviour //source: https://forum.unity.com/threads/2d-lookat.99708/
{
    public Transform target; //Add target in inspector

    void Update()
    {
        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(target.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }
}
