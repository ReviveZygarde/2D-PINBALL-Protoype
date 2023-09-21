using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*
 * S C O R E        S I M U L A T O R       M E N U
 * 
 * The aim of this is to make sure the under-the-hood stuff works by itself, automatically.
 * 
 * Use the menus in the scene to simulate the score calculation that
 * would play in-game.
 * 
 * [Jumper bumps] are +10 points.
 * 
 * Ball Saver ON is on for a set timer, when it reaches 5 seconds left,
 * ball saver state goes to ALMOST_END, and then OFF when timer reaches 0.
 * 
 * Hole 1, 2, and 3 goes to a different mode. Modes that are on a timer are Rush, Rhythm, and BOSS.
 * BOSS Mode is the only score that applies a Timer Leftover Bonus. (if mode = boss then add +200 points every 10 int or w/e)
 * 
 * [Hole/Ramp Bonus] adds +100 points.
 * In the real game, if the ball enters a hole, the ball gets Disabled, repositions transform
 * to the hole for 2 seconds, gets spat out with the hole's collider OFF for 1-2 seconds.
 * 
 * [Consume Ball] is if the ball enters the pit when saver is OFF. if saver is ON, it will do nothing.
 * 
 * */

public class scoreSim_menuBehavior : MonoBehaviour
{
    public ModeBehavior modeBehavior;
    public scoreBehavior scoreBehavior;
    public tableTally tally;
    public Text scoreCounter;
    public Text modeIndicator;
    public Text saverIndicator;
    public Text scoreMultiplierIndicator;
    public Text hole1count;
    public Text hole2count;
    public Text hole3count;
    public Text rampCount;
    public Text modeTimer;
    public Text saverTimer;
    public Text ballsLeft;
    public Button consumeBall;
    public Button hole1;
    public Button hole2;
    public Button hole3;
    public Button ramp;
    public Button jumper;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        //Instead of gameplay, the menu based simulation will just have buttons to extensively test the ModeBehavior.
        consumeBall.onClick.AddListener(modeBehavior.consumeBall);
        hole1.onClick.AddListener(tally.tallyHole1);
        hole2.onClick.AddListener(tally.tallyHole2);
        hole3.onClick.AddListener(tally.tallyHole3);
        ramp.onClick.AddListener(tally.tallyRamp);
        jumper.onClick.AddListener(tally.tallyBumper);
        exit.onClick.AddListener(gotoMenu);
    }

    void gotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = $"{scoreBehavior.pl_score}";
        saverIndicator.text = $"{modeBehavior.ballSaverState}";
        modeIndicator.text = $"{modeBehavior.modeState}";
        scoreMultiplierIndicator.text = $"{scoreBehavior.multiplierState}";
        ballsLeft.text = $"{scoreBehavior.ballsLeft}";
        saverTimer.text = $"{modeBehavior.secondsUntilBallSaveEnds}";
        modeTimer.text = $"{modeBehavior.secondsUntilModeEnds}";
        hole1count.text = $"{tally.hole1entryTally}";
        hole2count.text = $"{tally.criteria_hole2entry}";
        hole3count.text = $"{tally.criteria_hole3entry}";
        rampCount.text = $"{tally.criteria_ramp_entry}";
    }
}
