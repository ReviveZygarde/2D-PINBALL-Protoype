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
    private ModeBehavior mode;
    [SerializeField] lookAtPinball PinballLockonToDisable;
    [SerializeField] GameObject bossTriggerArea;
    [Tooltip("Keep this array at 2 items. Index 0 will be the standard animation, index 1 will be the 'defeated' or 'disabled' state.")]
    [SerializeField] GameObject[] bossAppearance;
    [SerializeField] GameObject bossEntity;

    // Start is called before the first frame update
    void Start()
    {
        pinball = GameObject.Find("Pinball");
        mode = GameObject.Find("common").GetComponent<ModeBehavior>();
        bossEntity = GameObject.Find("bossEntity");
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
            if(splineAnimator != null)
            {
                splineAnimator.Pause();
            }
        }
        if(mode.modeState == ModeBehavior.currentMode.RUSH)
        {
            mode.secondsUntilModeEnds = mode.secondsUntilModeEnds + 2;
            uiOverheadText.text = $"TIME EXTENSION! +2 SEC.";
        }
        if(mode.secondsUntilModeEnds >= 200) //similar to the roulette wheel, if the time exceeds 200 go back down to 200 seconds.
        {
            mode.secondsUntilModeEnds = 200;
        }
        if(mode.modeState != ModeBehavior.currentMode.RUSH)
        {
            uiOverheadText.text = $"BUMPERS PAUSED FOR {waitTimer} SEC. GO! GO! GO!";
        }
        laserBeam.SetActive(false);
        if (PinballLockonToDisable.gameObject.activeSelf) //Make the boss look like it's "disabled," if it's active in the scene.
        {
            PinballLockonToDisable.enabled = false;
            bossTriggerArea.SetActive(false);
            bossAppearance[0].SetActive(false);
            bossAppearance[1].SetActive(true);
        }
        yield return new WaitForSecondsRealtime(waitTimer);
        foreach (SplineAnimate splineAnimator in splineAnimators)
        {
            splineAnimator.Play();
        }
        laserBeam.SetActive(true);
        if (PinballLockonToDisable.gameObject.activeSelf) //Make the boss behave normally, if it's active in the scene.
        {
            PinballLockonToDisable.enabled = true;
            bossTriggerArea.SetActive(true);
            bossAppearance[0].SetActive(true);
            bossAppearance[1].SetActive(false);
            bossEntity.GetComponent<Collider2D>().enabled = true;
            bossEntity.GetComponent<SplineAnimate>().enabled = true;
        }
        yield return null;
    }
}
