using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeTimerBoxManager : MonoBehaviour
{
    private ModeBehavior common_modeBehavior;
    public GameObject timerBox;
    public Text timerCounter;

    // Start is called before the first frame update
    void Start()
    {
        common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(common_modeBehavior.modeState == ModeBehavior.currentMode.RUSH || common_modeBehavior.modeState == ModeBehavior.currentMode.RHYTHM || common_modeBehavior.modeState == ModeBehavior.currentMode.BOSS || common_modeBehavior.modeState == ModeBehavior.currentMode.CRACK)
        {
            timerBox.SetActive(true);
            timerCounter.text = $"{common_modeBehavior.secondsUntilModeEnds}";
        }
        else
        {
            timerBox.SetActive(false);
        }
    }
}
