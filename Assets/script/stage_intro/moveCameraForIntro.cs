using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moveCameraForIntro : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public float smoothTime = 30F;
    private Vector3 velocity = Vector2.zero;
    public float maxSpeed;
    public introCutscenCameraManager camManager;
    public float waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, transform.position.z - 10);
        StartCoroutine(tellManagerToChange());
    }

    IEnumerator tellManagerToChange()
    {
        yield return new WaitForSeconds(waitTimer);
        camManager.changeCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.SmoothDamp(transform.position, endPoint.transform.position, ref velocity, smoothTime);
        transform.position = Vector3.SmoothDamp(transform.position, endPoint.transform.position, ref velocity, smoothTime, maxSpeed, Time.deltaTime);
    }
}
