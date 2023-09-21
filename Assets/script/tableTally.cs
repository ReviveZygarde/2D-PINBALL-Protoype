using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void tallyHole1()
    {
        hole1entryTally++;
        scoreComponent.pl_score = scoreComponent.pl_score + 100;
    }

    public void tallyHole2()
    {
        hole2entryTally++;
        scoreComponent.pl_score = scoreComponent.pl_score + 100;
        if (modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
        {
            criteria_hole2entry++;
            hole_2_3_rampCheck();
        }
    }

    public void tallyHole3()
    {
        hole3entryTally++;
        scoreComponent.pl_score = scoreComponent.pl_score + 100;
        if (modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
        {
            criteria_hole3entry++;
            hole_2_3_rampCheck();
        }
    }

    public void tallyRamp()
    {
        rampTally++;
        scoreComponent.pl_score = scoreComponent.pl_score + 500;
        if (modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
        {
            criteria_ramp_entry++;
            hole_2_3_rampCheck();
        }
    }
    public void tallyBumper()
    {
        bumperTally++;
        scoreComponent.pl_score = scoreComponent.pl_score + 20;
    }
    private void hole_2_3_rampCheck() //checks if the ball has been to certain places X amount of times to begin the commented Mode.
    {
        if (criteria_hole2entry >= 3)
        {
            resetCriteriaHoleEntries();
            // start rhythm mode or Multi-ball based on RNG between 0-1.
            int randomNumber = Random.Range(0, 1);
            if(randomNumber == 0)
            {
                modeBehavior.modeState = ModeBehavior.currentMode.RHYTHM;
            }
            else
            {
                modeBehavior.modeState = ModeBehavior.currentMode.MULTIBALL;
            }
            modeBehavior.timerCountdownStart();
        }
        if (criteria_hole3entry >= 3)
        {
            resetCriteriaHoleEntries();
            //start boss mode
            modeBehavior.modeState = ModeBehavior.currentMode.BOSS;
            modeBehavior.timerCountdownStart();
        }
        if (criteria_ramp_entry >= 6)
        {
            resetCriteriaHoleEntries();
            //start rush mode
            modeBehavior.modeState = ModeBehavior.currentMode.RUSH;
            modeBehavior.timerCountdownStart();
        }
    }

    private void resetCriteriaHoleEntries()
    {
        StopAllCoroutines();
        criteria_hole2entry = 0;
        criteria_hole3entry = 0; //Note to self I need better naming conventions.
        criteria_ramp_entry = 0;
    }

}
