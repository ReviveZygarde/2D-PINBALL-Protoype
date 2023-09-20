using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    int multiplierFromScoreComponentOnCalculation;

    private scoreBehavior scoreComponent;
    private tableTally tally;

    /// <summary>
    /// TODO:
    /// - Add timer for Ball Saver (COROUTINE!!!!) - done
    /// - Make sure ConsumeBall does not make the ball count go down when saver is active -- done.
    /// - Make the holes and jumper bumps increase score.
    /// - When one of the hole entry count reaches 3, reset the counter for all 3 holes and then start the mode.
    ///   (and when a mode that is NOT normal is happening, do NOT make the counter go up)
    /// - When any other mode is active that is NOT Normal/Multiball/Crack, make the ball saver timer infinite,
    ///   but also start the mode timer, and when that reaches 0 go to END_MODE, calculate score, increase multiplier
    ///   state, then NORMAL. -- Done. Score calculation may need to be revised as the project continues.
    /// - When ball is consumed and saver is off, multiply the score with the Multiplier. Respawn ball, re-enable ball saver and it's timer.
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {
        scoreComponent = GetComponent<scoreBehavior>();
        predefined_secondsUntilBallSaveEnds = secondsUntilBallSaveEnds;
        predefined_secondsUntilModeEnds = secondsUntilModeEnds;
        timerCountdownStart(); //This would be called as soon as the ball is launched from the spring.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void timerCountdownStart()
    {
        if(modeState == currentMode.RUSH || modeState == currentMode.RHYTHM || modeState == currentMode.BOSS) //timer countdown relating to mode
        {
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
        }
        if(secondsUntilModeEnds <= 0)
        {
            modeState = currentMode.MODE_END;
            ScoreCalculate(); //Calculate score method goes here...
            yield return new WaitForSeconds(1f);
            secondsUntilModeEnds = predefined_secondsUntilModeEnds;
        }
        yield return null;
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
                }
                break;
            case scoreBehavior.multiplier.X2:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X2)
                {
                    multiplierFromScoreComponentOnCalculation = 2;
                }
                break;
            case scoreBehavior.multiplier.X4:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X4)
                {
                    multiplierFromScoreComponentOnCalculation = 4;
                }
                break;
            case scoreBehavior.multiplier.X6:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X6)
                {
                    multiplierFromScoreComponentOnCalculation = 6;
                }
                break;
            case scoreBehavior.multiplier.X8:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X8)
                {
                    multiplierFromScoreComponentOnCalculation = 8;
                }
                break;
            case scoreBehavior.multiplier.X10:
                if (scoreComponent.multiplierState == scoreBehavior.multiplier.X10)
                {
                    multiplierFromScoreComponentOnCalculation = 10;
                }
                break;
        }
        if(secondsUntilModeEnds == 0) //if there is no time left by the time the mode ends, no bonus is applied.
        {
            revertModeToNormal(); //The game mode state goes back to Normal.
        }
        else //the bonus will be applied if you have at at least 1 second left on the timer.
        {
            scoreComponent.pl_score = scoreComponent.pl_score + (secondsUntilModeEnds * multiplierFromScoreComponentOnCalculation) * (scoreComponent.ballsLeft + 1);
            revertModeToNormal();
        }
    }

    private void revertModeToNormal()
    {
        modeState = currentMode.NORMAL;
        secondsUntilBallSaveEnds = predefined_secondsUntilBallSaveEnds;
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
                    }
                    else
                    {
                        scoreComponent.ballsLeft--;
                        ballSaverState = ballSaver.ON;
                        revertModeToNormal();
                    }
                }
                break;
        }
    }
}
