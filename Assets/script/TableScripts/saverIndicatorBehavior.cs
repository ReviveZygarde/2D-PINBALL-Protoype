using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saverIndicatorBehavior : MonoBehaviour
{
    public GameObject SAVER_OK;
    public GameObject SAVER_OFF;
    public ModeBehavior common_ModeBehavior;

    private void Start()
    {
        StartCoroutine(indicatorFlash());
    }

    IEnumerator indicatorFlash() //just to make the corotutine constantly run every second if it's not in ALMOST_END mode. also to prevent the coroutine from
                                 //actually stopping.
    {
        while(common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.ON)
        {
            yield return new WaitForSecondsRealtime(1f);
        }
        while (common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.OFF)
        {
            yield return new WaitForSecondsRealtime(1f);
        }
        while (common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.ALMOST_END)
        {
            SAVER_OK.SetActive(true);
            yield return new WaitForSecondsRealtime(0.25f);
            SAVER_OK.SetActive(false);
            SAVER_OFF.SetActive(true);
            yield return new WaitForSecondsRealtime(0.25f);
            SAVER_OFF.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.ON)
        {
            SAVER_OK.SetActive(true);
            SAVER_OFF.SetActive(false);
        }
        if (common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.OFF)
        {
            SAVER_OK.SetActive(false);
            SAVER_OFF.SetActive(true);
        }
    }
}
