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
    private bool ok;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        if (isText)
        {
            ok = true;
        }
        yield return new WaitForSeconds(0.5f);
        ok = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (ok)
        {
            transform.position = Vector2.SmoothDamp(transform.position, destination.transform.position, ref velocity, 0.5f, Mathf.Infinity, Time.deltaTime);
        }
    }
}
