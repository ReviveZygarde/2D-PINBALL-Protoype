using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class pauseSplineTimer : MonoBehaviour
{
    [SerializeField] private List<SplineAnimate> splineAnimators;
    private Collider2D col;
    private GameObject pinball;
    public float waitTimer;
    public Text uiOverheadText;
    [SerializeField] GameObject laserBeam;

    // Start is called before the first frame update
    void Start()
    {
        pinball = GameObject.Find("Pinball");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == pinball)
        {
            StartCoroutine(pauseSplines());
        }
    }

    IEnumerator pauseSplines()
    {
        foreach(SplineAnimate splineAnimator in splineAnimators)
        {
            splineAnimator.Pause();
        }
        uiOverheadText.text = $"BUMPERS PAUSED FOR {waitTimer} SEC. GO! GO! GO!";
        laserBeam.SetActive(false);
        yield return new WaitForSecondsRealtime(waitTimer);
        foreach (SplineAnimate splineAnimator in splineAnimators)
        {
            splineAnimator.Play();
        }
        laserBeam.SetActive(true);
        yield return null;
    }
}
