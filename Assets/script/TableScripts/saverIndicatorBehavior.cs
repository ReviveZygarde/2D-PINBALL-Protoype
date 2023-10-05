using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saverIndicatorBehavior : MonoBehaviour
{
    public GameObject SAVER_OK;
    public GameObject SAVER_ALMOST_END;
    public GameObject SAVER_OFF;
    public ModeBehavior common_ModeBehavior;

    // Update is called once per frame
    void Update()
    {
        if(common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.ON)
        {
            SAVER_OK.SetActive(true);
            SAVER_ALMOST_END.SetActive(false);
            SAVER_OFF.SetActive(false);
        }
        if (common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.ALMOST_END)
        {
            SAVER_OK.SetActive(false);
            SAVER_ALMOST_END.SetActive(true);
            SAVER_OFF.SetActive(false);
        }
        if (common_ModeBehavior.ballSaverState == ModeBehavior.ballSaver.OFF)
        {
            SAVER_OK.SetActive(false);
            SAVER_ALMOST_END.SetActive(false);
            SAVER_OFF.SetActive(true);
        }
    }
}
