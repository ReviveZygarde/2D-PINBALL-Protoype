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

    public int secondsUntilBallSaveEnds;
    public int secondsUntilModeEnds;

    //"Predefined" variables. What the timer resets back to.
    private int predefined_secondsUntilBallSaveEnds;
    private int predefined_secondsUntilModeEnds;

    /// <summary>
    /// TODO:
    /// - Add timer for Ball Saver (COROUTINE!!!!)
    /// - Make sure ConsumeBall does not make the ball count go down when saver is active
    /// - Make the holes and jumper bumps increase score.
    /// - When one of the hole entry count reaches 3, reset the counter for all 3 holes and then start the mode.
    ///   (and when a mode that is NOT normal is happening, do NOT make the counter go up)
    /// - When any other mode is active that is NOT Normal/Multiball/Crack, make the ball saver timer infinite,
    ///   but also start the mode timer, and when that reaches 0 go to END_MODE, calculate score, increase multiplier
    ///   state, then NORMAL.
    /// - When ball is consumed and saver is off, multiply the score with the Multiplier. Respawn ball, re-enable ball saver and it's timer.
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {
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
        //math stuff goes here
        revertModeToNormal();
    }

    private void revertModeToNormal()
    {
        modeState = currentMode.NORMAL;
        timerCountdownStart();
    }
}
