using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class railwayLineTallier : MonoBehaviour
{
    public enum tallyType {NONE, BOSS, RUSH, RHYTHM}
    public tallyType type;
    public GameObject Pinball;
    public tableTally common_tally;
    public ModeBehavior mode;
    [SerializeField] private Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        common_tally = GameObject.Find("common").GetComponent<tableTally>();
        mode = GameObject.Find("common").GetComponent<ModeBehavior>();
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            doTheTally();
        }
    }

    void doTheTally()
    {
        switch (type)
        {
            case tallyType.NONE:
                common_tally.hole1entryTally++;
                break;
            case tallyType.BOSS:
                if(mode.modeState == ModeBehavior.currentMode.NORMAL)
                {
                    common_tally.criteria_hole3entry++;
                    common_tally.hole_2_3_rampCheck();
                }
                break;
            case tallyType.RUSH:
                common_tally.tallyRamp();
                if (mode.modeState == ModeBehavior.currentMode.RUSH)
                {
                    StartCoroutine(statusTextChange());
                }
                break;
            case tallyType.RHYTHM:
                if (mode.modeState == ModeBehavior.currentMode.NORMAL)
                {
                    common_tally.criteria_hole2entry++;
                    common_tally.hole_2_3_rampCheck();
                }
                break;
        }

        if(mode.modeState == ModeBehavior.currentMode.RUSH || mode.modeState == ModeBehavior.currentMode.BOSS)
        {
            //Make a coroutine that extends the time, and then make this call the coroutine.
            StartCoroutine(timeExtension());
        }

        if (mode.modeState == ModeBehavior.currentMode.RUSH || mode.modeState == ModeBehavior.currentMode.CRACK)
        {
            speedUp();
        }
    }

    IEnumerator timeExtension()
    {
        mode.secondsUntilModeEnds = mode.secondsUntilModeEnds + 10;
        if(mode.secondsUntilModeEnds >= 200)
        {
            mode.secondsUntilModeEnds = 200;
        }
        yield return new WaitForSeconds(2f);
        statusText.text = "TIME EXTENSION!";
        yield return new WaitForSeconds(2f);
        statusText.text = "+10 SECONDS";
        yield return null;
    }

    void speedUp()
    {
        statusText.text = "LET'S SPEED IT UP!!!";
        Time.timeScale = Time.timeScale + 0.15f;
        //yield return null;
    }

    IEnumerator statusTextChange()
    {
        if (mode.modeState == ModeBehavior.currentMode.NORMAL)
        {
            statusText.text = "AROUND THE RAMP!";
            yield return new WaitForSeconds(3f);
            statusText.text = $"{4 - common_tally.criteria_ramp_entry} MORE FOR RUSH!";
            yield return null;
        }
    }

}
