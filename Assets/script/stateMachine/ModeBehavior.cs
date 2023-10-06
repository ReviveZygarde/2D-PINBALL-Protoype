using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeBehavior : MonoBehaviour
{
    public enum currentMode
    { NORMAL, RUSH, RHYTHM, BOSS, CRACK, MULTIBALL, MODE_END}
    public currentMode modeState = currentMode.NORMAL;

    public enum ballSaver
    { ON, OFF, ALMOST_END}
    public ballSaver ballSaverState = ballSaver.ON;

    //for timer
    public int secondsUntilBallSaveEnds;
    public int secondsUntilModeEnds;

    //"Predefined" variables. What the timer resets back to.
    private int predefined_secondsUntilBallSaveEnds;
    private int predefined_secondsUntilModeEnds;

    //Regular integer to determine how much the score gets multiplied. See
    //the switch-case on how the scoreBehavior's multiplierState affects this.
    private int multiplierFromScoreComponentOnCalculation;

    private scoreBehavior scoreComponent;
    private tableTally tally;

    private bool hasAlreadyReachedEndgame; //boolean that prevents crack mode from constantly triggering after every score calculation. Instead, it should every other mode.

    /// <summary>
    /// TODO:
    /// - DONE: Add timer for Ball Saver (COROUTINE!!!!)
    /// - DONE: Make sure ConsumeBall does not make the ball count go down when saver is active
    /// - DONE: Make the holes and jumper bumps increase score.
    /// - DONE: When one of the hole entry count reaches 3, reset the counter for all 3 holes and then start the mode.
    ///   (and when a mode that is NOT normal is happening, do NOT make the counter go up)
    /// - DONE: (Score calculation may need to be revised as the project continues.) - When any other mode is active
    ///   that is NOT Normal/Multiball/Crack, make the ball saver timer infinite,
    ///   but also start the mode timer, and when that reaches 0 go to END_MODE, calculate score, increase multiplier
    ///   state, then NORMAL.
    /// - DONE: When ball is consumed and saver is off, multiply the score with the Multiplier. Respawn ball, re-enable ball saver and it's timer.
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {
        scoreComponent = GetComponent<scoreBehavior>();
        tally = GetComponent<tableTally>();
        predefined_secondsUntilBallSaveEnds = secondsUntilBallSaveEnds;
        predefined_secondsUntilModeEnds = secondsUntilModeEnds;
        timerCountdownStart(); //This would be called as soon as the ball is launched from the spring.
    }

    public void timerCountdownStart()
    {
        StopAllCoroutines();
        if (modeState == currentMode.RUSH || modeState == currentMode.RHYTHM || modeState == currentMode.BOSS) //timer countdown relating to mode
        {
            ballSaverState = ballSaver.ON;
            StartCoroutine(timerCountdown_Mode());
        }
        else //timer countdown relating to ball saver
        {
            StartCoroutine(timerCountdown_Saver());
        }
        return;
    }

    IEnumerator timerCountdown_Saver()
    {
        while (secondsUntilBallSaveEnds > 0) //Performing the cardinal sin of using WHILE... so the coroutine doesn't happen twice at once.
        {
            yield return new WaitForSeconds(1f);
            decrementSaverTimerBy1();
        }
        if (secondsUntilBallSaveEnds <= 0)
        {
            ballSaverState = ballSaver.OFF;
        }
        yield return null;
    }

    IEnumerator timerCountdown_Mode()
    {
        while(secondsUntilModeEnds > 0)
        {
            secondsUntilBallSaveEnds = 99;
            yield return new WaitForSeconds(1f);
            decrementModeTimerBy1();
            if (secondsUntilModeEnds <= 0)
            {
                modeState = currentMode.MODE_END;
                ScoreCalculate(); //Calculate score method goes here... Do not put any methods or code below this method. This method will STOP All coroutines and will not
                                  //call anything below this.
                                  //yield return new WaitForSeconds(1f);
                yield return null;
            }
        }
    }

    private void decrementSaverTimerBy1()
    {
        secondsUntilBallSaveEnds--;
        if(secondsUntilBallSaveEnds == 10)
        {
            ballSaverState = ballSaver.ALMOST_END;
        }
    }

    private void decrementModeTimerBy1()
    {
        secondsUntilModeEnds--;
    }

    private void ScoreCalculate()
    {
        //The int variable, multiplierFromScoreComponentOnCalculation, is determined
        //by the Multiplier state machine from the scoreBehavior component.
        switch (scoreComponent.multiplierState)
        {
            case scoreBehavior.multiplier.X1:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X1)
                {
                    multiplierFromScoreComponentOnCalculation = 1;
                    scoreComponent.multiplierState = scoreBehavior.multiplier.X2;
                }
                break;
            case scoreBehavior.multiplier.X2:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X2)
                {
                    multiplierFromScoreComponentOnCalculation = 2;
                    scoreComponent.multiplierState = scoreBehavior.multiplier.X4;
                }
                break;
            case scoreBehavior.multiplier.X4:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X4)
                {
                    multiplierFromScoreComponentOnCalculation = 4;
                    scoreComponent.multiplierState = scoreBehavior.multiplier.X6;
                }
                break;
            case scoreBehavior.multiplier.X6:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X6)
                {
                    multiplierFromScoreComponentOnCalculation = 6;
                    scoreComponent.multiplierState = scoreBehavior.multiplier.X8;
                }
                break;
            case scoreBehavior.multiplier.X8:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X8)
                {
                    multiplierFromScoreComponentOnCalculation = 8;
                    scoreComponent.multiplierState = scoreBehavior.multiplier.X10;
                }
                break;
            case scoreBehavior.multiplier.X10:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X10)
                {
                    multiplierFromScoreComponentOnCalculation = 10;
                }
                break;  
        }
        if(secondsUntilModeEnds == 0) //if there is no time left by the time the mode ends, no Time Leftover Bonus is applied.
        {
            scoreComponent.pl_score = (int)(Time.timeScale * scoreComponent.pl_score * multiplierFromScoreComponentOnCalculation * (scoreComponent.ballsLeft + 1));
            revertModeToNormal(); //The game mode state goes back to Normal.
        }
        else //the Time Leftover bonus will be applied if you have at at least 1 second left on the timer.
        {
            scoreComponent.pl_score = scoreComponent.pl_score + (secondsUntilModeEnds * multiplierFromScoreComponentOnCalculation) * (scoreComponent.ballsLeft + 1);
            revertModeToNormal();
        }
    }

    /*
     * Some really freaky stuff happens in these blocks of code. After the game checks if crack mode can be unlocked,
     * it has to timerCountdownStart or else it'll get stuck on MODE_END. This is because I used a WHILE Loop and the game
     * actually softlocks because I did not break out of the loop at the correct time. Therefore. It unintentionally is gonna
     * make crack mode 10x harder than i intended but I guess I'll leave it at that for the actual game.
     * The "hasAlreadyReachedEndgame" boolean is to make sure crack mode does NOT constantly happen. Again, this is rare,
     * so I don't think anyone would actually see this unintended bug, but who knows.
     * 
     * TL;DR: Crack Mode doesn't work on a timer, so technically it lasts infinitely, but the Ball Saver timer still works.
     * The only way to get out of it is if you lose the mode.
     */

    private void revertModeToNormal()
    {
        Time.timeScale = 1f; //Timescale is put here in case if the mode that ended was rush, so this undoes the changes rush mode did.
        modeState = currentMode.NORMAL;
        secondsUntilBallSaveEnds = predefined_secondsUntilBallSaveEnds;
        secondsUntilModeEnds = predefined_secondsUntilModeEnds;
            StopAllCoroutines();
            if (scoreComponent.multiplierState == scoreBehavior.multiplier.X10)
            {
                if (!hasAlreadyReachedEndgame)
                {
                    checkCrackMode();
                }
            }
        timerCountdownStart();
    }

    public void consumeBall()
    {
        switch (ballSaverState)
        {
            case ballSaver.ON:
                if(ballSaverState == ballSaver.ON)
                {
                    return; //intentionally do nothing for now in the menu simulation.
                            //In the actual game, though, make the ball respawn at the
                            //starting point.
                }
                break;
            case ballSaver.ALMOST_END:
                if(ballSaverState == ballSaver.ALMOST_END)
                {
                    return;
                }
                break;
            case ballSaver.OFF:
                if(ballSaverState == ballSaver.OFF)
                {
                    if(scoreComponent.ballsLeft <= 0)
                    {
                        Debug.Log("Final score is displayed here, calculated with the multiplier. Show game over screen.");
                        SceneManager.LoadScene(6);
                    }
                    else
                    {
                        scoreComponent.ballsLeft--;
                        ballSaverState = ballSaver.ON;
                        scoreComponent.pl_score = scoreComponent.pl_score + tally.bumperTally + tally.rampTally + tally.hole1entryTally;
                        tally.resetAllTallies();
                        revertModeToNormal();
                    }
                }
                break;
        }
    }

    private void checkCrackMode()
    {
        if (scoreComponent.multiplierState == scoreBehavior.multiplier.X10)
        {
            //begin CRACK MODE 
            modeState = currentMode.CRACK;
            hasAlreadyReachedEndgame = true;
            StopAllCoroutines();
        }
    }
}
