using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ModeBehavior;

/* T A B L E  T A L L Y
 * 
 * Keeps track of how many holes the ball has entered,
 * how many bumpers were in contact, and how many ramp
 * loops it went through. These will be factored in the
 * score calculation.
 * 
 * */
public class tableTally : MonoBehaviour
{
    private scoreBehavior scoreComponent;
    private ModeBehavior modeBehavior;

    //Summative tallies for final score calculation
    public int hole1entryTally;
    public int hole2entryTally;
    public int hole3entryTally;
    public int rampTally;
    public int bumperTally;

    //Tallies that will reset to 0 once certain criteria are met. These are needed to activate the other modes.
    public int criteria_hole2entry;
    public int criteria_hole3entry;
    public int criteria_ramp_entry;

    // Start is called before the first frame update
    void Start()
    {
        scoreComponent = GetComponent<scoreBehavior>();
        modeBehavior = GetComponent<ModeBehavior>();
    }

    private void tallyHole1()
    {
        hole1entryTally++;
    }

    private void tallyHole2()
    {
        hole2entryTally++;
        if (modeBehavior.modeState == currentMode.NORMAL)
        {
            criteria_hole2entry++;
            hole_2_3_rampCheck();
        }
    }

    private void tallyHole3()
    {
        hole3entryTally++;
        if (modeBehavior.modeState == currentMode.NORMAL)
        {
            criteria_hole3entry++;
            hole_2_3_rampCheck();
        }
    }

    private void tallyRamp()
    {
        rampTally++;
        if (modeBehavior.modeState == currentMode.NORMAL)
        {
            criteria_ramp_entry++;
            hole_2_3_rampCheck();
        }
    }
    private void tallyBumper()
    {
        bumperTally++;
    }
    private void hole_2_3_rampCheck()
    {
        if (criteria_hole2entry >= 3)
        {
            // start rhythm mode
        }
        if (criteria_hole3entry >= 3)
        {
            //start boss mode
        }
        if (criteria_ramp_entry >= 6)
        {
            //start rush mode
        }
        criteria_hole2entry = 0;
        criteria_hole2entry = 0;
        criteria_ramp_entry = 0;
    }

}
