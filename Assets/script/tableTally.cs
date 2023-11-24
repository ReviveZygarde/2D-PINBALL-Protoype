using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

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

    //bossEntity GameObject
    public GameObject bossEntity;

    //Interrupt Event stuff for UI
    public GameObject interruptEvent_Boss;
    public GameObject interruptEvent_Rush;
    public GameObject interruptEvent_Rhythm;
    private commonAudioManager AudioManager;

    //for the RhythmMode Manager
    public GameObject rhythmParent;

    // Start is called before the first frame update
    void Start()
    {
        scoreComponent = GetComponent<scoreBehavior>();
        AudioManager = GetComponent<commonAudioManager>();
        modeBehavior = GetComponent<ModeBehavior>();
        bossEntity = GameObject.Find("bossEntity");
        //interruptEvent_Boss.SetActive(false);
        //interruptEvent_Rush.SetActive(false);
        bossEntity.SetActive(false);
    }

    public void tallyHole1(GameObject passedGO) //Takes in the passed GameObject from whatever hole1behavior is calling it.
    {
        hole1behavior temp_holeParam = passedGO.GetComponent<hole1behavior>(); //Local variable of hole1behavior component. Only for checking bool flags.
        scoreComponent.pl_score = scoreComponent.pl_score + 100;
        if (temp_holeParam.isRegularHole1 == true)
        {
            hole1entryTally++;
            return;
        }
        else if(temp_holeParam.isRhythmMultiballHole2 == true)
        {
            hole2entryTally++;
            if (modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
            {
                criteria_hole2entry++;
            }
        }
        else if (temp_holeParam.isBossHole3 == true)
        {
            hole3entryTally++;
            if (modeBehavior.modeState == ModeBehavior.currentMode.NORMAL)
            {
                criteria_hole3entry++;
            }
        }
        hole_2_3_rampCheck();
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
            modeBehavior.modeState = ModeBehavior.currentMode.RHYTHM;
            StartCoroutine(interruptRhythmEventPopUp());
        }
        if (criteria_hole3entry >= 3)
        {
            resetCriteriaHoleEntries();
            //start boss mode
            modeBehavior.modeState = ModeBehavior.currentMode.BOSS;
            bossEntity.SetActive(true); //We summon the "boss" for the player to kill.
            StartCoroutine(interruptBossEventPopUp());
        }
        if (criteria_ramp_entry >= 4)
        {
            resetCriteriaHoleEntries();
            //start rush mode
            modeBehavior.modeState = ModeBehavior.currentMode.RUSH;
            StartCoroutine(interruptRushEventPopUp());
        }
    }

    private void resetCriteriaHoleEntries()
    {
        StopAllCoroutines();
        criteria_hole2entry = 0;
        criteria_hole3entry = 0; //Note to self I need better naming conventions.
        criteria_ramp_entry = 0;
    }

    public void resetAllTallies()
    {
        hole1entryTally = 0;
        hole2entryTally = 0;
        hole3entryTally = 0;
        rampTally = 0;
        bumperTally = 0;
        criteria_hole2entry = 0;
        criteria_hole3entry = 0;
        criteria_ramp_entry = 0;
    }

    IEnumerator interruptBossEventPopUp()
    {
        interruptEvent_Boss.SetActive(true);
        AudioManager.vo_mission.Play();
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1.0f;
        common_interruptEventUImanager ui_manager = GetComponent<common_interruptEventUImanager>();
        ui_manager.resetBossInterruptBars();
        interruptEvent_Boss.SetActive(false);
        modeBehavior.timerCountdownStart();
        yield return null;
    }

    IEnumerator interruptRushEventPopUp()
    {
        interruptEvent_Rush.SetActive(true);
        AudioManager.vo_mission.Play();
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1.0f;
        common_interruptEventUImanager ui_manager = GetComponent<common_interruptEventUImanager>();
        //ui_manager.resetBossInterruptBars();
        interruptEvent_Rush.SetActive(false);
        modeBehavior.timerCountdownStart();
        yield return null;
    }

    IEnumerator interruptRhythmEventPopUp()
    {
        interruptEvent_Rhythm.SetActive(true);
        AudioManager.vo_mission.Play();
        Time.timeScale = 0f;
        rhythmParent.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1.0f;
        common_interruptEventUImanager ui_manager = GetComponent<common_interruptEventUImanager>();
        //ui_manager.resetBossInterruptBars();
        interruptEvent_Rhythm.SetActive(false);
        modeBehavior.timerCountdownStart();
        yield return null;
    }

}