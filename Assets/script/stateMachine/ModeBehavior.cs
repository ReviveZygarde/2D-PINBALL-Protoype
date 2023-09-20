using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeBehavior : MonoBehaviour
{
    public enum currentMode
    { NORMAL, RUSH, RHYTHM, BOSS, CRACK, MODE_END}
    public currentMode modeState = currentMode.NORMAL;

    public enum ballSaver
    { ON, OFF, ALMOST_END}
    public ballSaver ballSaverState = ballSaver.ON;

    public int secondsUntilBallSaveEnds;
    public int secondsUntilModeEnds;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
