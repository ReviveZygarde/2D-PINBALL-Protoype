using System.Collections;
using System.Collections.Generic;
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
    public Vector3 vec3; //Why does the UI use Vector3???

    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(waitToStartMoving);
        ok = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (ok)
        {
            transform.position = Vector2.SmoothDamp(transform.position, destination.transform.position, ref velocity, speedTime, Mathf.Infinity, Time.deltaTime);
        }
    }
}
