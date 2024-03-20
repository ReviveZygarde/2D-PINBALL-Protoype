using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Apple;

public class blackBars_gotoZero : MonoBehaviour
{
    private Vector2 velocity; //= Vector2.zero;
    public GameObject destination;
    public bool isText;
    public float speedTime = 0.5f;
    public float waitToStartMoving = 0.5f;
    private bool ok;
    public RectTransform rectTransform;
    [Tooltip("Bypass the Timescale if it is not 1. If the timescale is always 1, leave this OFF.")]
    [SerializeField] private bool bypassTimescale;
    [Tooltip("The specified DeltaTime you want this Behavior to use instead of relying on Time.DeltaTime. Only used if bypassTimescale is ON.")]
    [SerializeField] private float startDeltaTime = 0.0021761f; //float for TimeScale that is set to 1.
    public Vector3 vec3; //Why does the UI use Vector3???

    // Start is called before the first frame update
    void Start()
    {
        //startDeltaTime = Time.deltaTime;
        StartCoroutine(waitToStart());
        rectTransform = GetComponent<RectTransform>();
        vec3 = rectTransform.localPosition;
    }

    private void OnEnable()
    {
        if(rectTransform != null)
        {
            rectTransform.localPosition = vec3;
        }
        ok = false;
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        if (isText)
        {
            ok = true;
        }
        yield return new WaitForSecondsRealtime(waitToStartMoving);
        ok = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        //Ayiyai I know this is not very efficient... But this is some manual way to keep the SmoothDamp while bypassing the zero TimeScale.
        if (ok)
        {
            if (bypassTimescale)
            {
                transform.position = Vector2.SmoothDamp(transform.position, destination.transform.position, ref velocity, speedTime, Mathf.Infinity, startDeltaTime);
            }
            else
            {
                transform.position = Vector2.SmoothDamp(transform.position, destination.transform.position, ref velocity, speedTime, Mathf.Infinity, Time.deltaTime);
            }
        }
    }
}
