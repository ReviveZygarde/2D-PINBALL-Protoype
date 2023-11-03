using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class bossTitleSplineAdjust : MonoBehaviour
{
    private SplineAnimate splineAnimator;

    // Start is called before the first frame update
    void Start()
    {
        splineAnimator = GetComponent<SplineAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActiveAndEnabled)
        {
            splineAnimator.Restart(true);
        }
    }
}
