using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigManager : MonoBehaviour
{
    public trigChildBehavior trig1;
    public trigChildBehavior trig2;
    public trigChildBehavior trig3;
    private tableTally common_tableTally;
    private ModeBehavior common_modeBehavior;
    private Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        common_tableTally = GameObject.Find("common").GetComponent<tableTally>();
        common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trig1.didEnter && trig2.didEnter && trig3.didEnter)
        {
            trig1.didEnter = false;
            trig2.didEnter = false;
            trig3.didEnter = false;
            StartCoroutine(statusTextChange());
            common_tableTally.tallyRamp();
        }
    }

    IEnumerator statusTextChange()
    {
        if(common_modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
        {
            statusText.text = "AROUND THE RAMP!";
            yield return new WaitForSeconds(3f);
            statusText.text = $"{6 - common_tableTally.criteria_ramp_entry} MORE FOR RUSH!";
            yield return new WaitForSeconds(3f);
            statusText.text = "";
            yield return null;
        }
        if(common_modeBehavior.modeState == ModeBehavior.currentMode.RUSH || common_modeBehavior.modeState == ModeBehavior.currentMode.CRACK)
        {
            statusText.text = "LET'S SPEED IT UP!!!";
            Time.timeScale = Time.timeScale + 0.15f;
            yield return new WaitForSeconds(3f);
            statusText.text = "";
            yield return null;
        }
    }
}
