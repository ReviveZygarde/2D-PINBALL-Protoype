using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverRampTallier : MonoBehaviour
{
    /// <summary>
    /// Code ported from trigManager.cs
    /// </summary>
    
    public GameObject Pinball;
    private tableTally common_tableTally;
    private ModeBehavior common_modeBehavior;
    private Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        common_tableTally = GameObject.Find("common").GetComponent<tableTally>();
        common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            StartCoroutine(statusTextChange());
            common_tableTally.tallyRamp();
        }
    }

    IEnumerator statusTextChange()
    {
        if (common_modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
        {
            statusText.text = "AROUND THE RAMP!";
            yield return new WaitForSeconds(3f);
            statusText.text = $"{6 - common_tableTally.criteria_ramp_entry} MORE FOR RUSH!";
            yield return new WaitForSeconds(3f);
            statusText.text = "";
            yield return null;
        }
        if (common_modeBehavior.modeState == ModeBehavior.currentMode.RUSH || common_modeBehavior.modeState == ModeBehavior.currentMode.CRACK)
        {
            statusText.text = "LET'S SPEED IT UP!!!";
            Time.timeScale = Time.timeScale + 0.15f;
            yield return new WaitForSeconds(3f);
            statusText.text = "";
            yield return null;
        }
    }

}
