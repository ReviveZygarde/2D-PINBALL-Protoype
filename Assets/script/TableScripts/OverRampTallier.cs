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
    private scoreBehavior common_scoreBehavior;
    private Text statusText;
    [SerializeField] private bool debug_OverWriteAsBoss;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        common_tableTally = GameObject.Find("common").GetComponent<tableTally>();
        common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        common_scoreBehavior = GameObject.Find("common").GetComponent<scoreBehavior>();
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            common_scoreBehavior.pl_score = common_scoreBehavior.pl_score + 100;
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
            statusText.text = $"{4 - common_tableTally.criteria_ramp_entry} MORE FOR RUSH!";
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

///some commented out code here for maybe future reference....... maybe.
/*
          if (common_modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
        {
            statusText.text = "AROUND THE RAMP!";
            yield return new WaitForSeconds(3f);
            if (!debug_OverWriteAsBoss)
            {
                statusText.text = $"{4 - common_tableTally.criteria_ramp_entry} MORE FOR RUSH!";
            }
            
            else if(debug_OverWriteAsBoss) //to change the behavior for the criteria tally to access BOSS Mode easier. Feel free to comment this out.
            {
                statusText.text = $"{3 - common_tableTally.criteria_hole3entry} MORE FOR BOSS! (debug)";
                common_tableTally.criteria_hole3entry++;
                common_tableTally.criteria_ramp_entry--;
            }
            
            yield return new WaitForSeconds(3f);
            statusText.text = "";
            yield return null;
        }
*/
