using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
#pragma warning disable 0108
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float staticXrotation = gameObject.transform.rotation.eulerAngles.x;
        float staticZrotation = gameObject.transform.rotation.eulerAngles.z;
        transform.LookAt(camera.transform);
        transform.rotation = Quaternion.Euler(staticXrotation, gameObject.transform.rotation.eulerAngles.y, staticZrotation);
    }
}
