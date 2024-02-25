using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class common_interruptEventUImanager : MonoBehaviour
{
    private scoreBehavior scoreComponent;
    private ModeBehavior modeComponent;
    private GameObject pl_input;
    private gameplayControlsBehavior confirmButton;
    public commonAudioManager audioManager;

    //This is to properly restart the UI position transforms and all that stuff to its initial values if possible.
    public GameObject modeFinishInterruptEvent;
    public Text modeFinishSpeedCounter;
    public Text modeFinishBallCounter;
    public Text modeFinishTimeCounter;
    public Text modeFinishMultiplyCounter;
    public Text modeFinishFinalScoreCounter;
    public Text specialMessage;
    public Text finishTitle;
    private int scoreDisplay;
    [SerializeField] private bool canShowScore;

    private int timeSubtract;
    private int ballSubtract;
    private int secondSubtract;


    // Start is called before the first frame update
    void Start()
    {
        scoreComponent = GetComponent<scoreBehavior>();
        modeComponent = GetComponent<ModeBehavior>();
        pl_input = GameObject.Find("pl_input");
        confirmButton = pl_input.GetComponent<gameplayControlsBehavior>();
        audioManager = GetComponent<commonAudioManager>();
    }

    /*
    public void resetBossInterruptBars()
    {
        //Finds UI game objects, and resets their localPosition to zero.
        GameObject tmp_UIbottomBars = GameObject.Find("int_b_barsBottom");
        GameObject tmp_UItopBars = GameObject.Find("int_b_barsTop");
        tmp_UIbottomBars.transform.localPosition = Vector2.zero;
        tmp_UItopBars.transform.localPosition = Vector2.zero;
    }
    */

    public void screenAfterCalculate()
    {
        modeFinishInterruptEvent.SetActive(true);
        if (modeComponent.didPlayerLoseBall)
        {
            finishTitle.text = "LOSE";
        }
        if (audioManager.stageBGM.isPlaying)
        {
            audioManager.stageBGM.Stop();
        }
        StartCoroutine(showModeEndStats());
    }

    IEnumerator showModeEndStats()
    {
        //This basically relays all the variable data on-screen.
        //Uses a WHILE loop to do the numbers counting down rapidly.

        canShowScore = false;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(0.5f);
        audioManager.SE_resultsStamp.Play();
        modeFinishSpeedCounter.text = $"{modeComponent.timescaleBonus * 10}";
        if (modeComponent.didPlayerLoseBall) { modeFinishSpeedCounter.text = ""; }
        yield return new WaitForSecondsRealtime(0.5f);
        audioManager.SE_resultsStamp.Play();
        modeFinishBallCounter.text = $"{(scoreComponent.ballsLeft * 100)}";
        if (modeComponent.didPlayerLoseBall) { modeFinishBallCounter.text = ""; }
        yield return new WaitForSecondsRealtime(0.5f);
        audioManager.SE_resultsStamp.Play();
        modeFinishTimeCounter.text = $"{modeComponent.secondsUntilModeEnds * modeComponent.multiplierFromScoreComponentOnCalculation * 100}";
        if (modeComponent.didPlayerLoseBall) { modeFinishTimeCounter.text = ""; }
        yield return new WaitForSecondsRealtime(0.5f);
        audioManager.SE_resultsStamp.Play();
        modeFinishMultiplyCounter.text = $"{modeComponent.multiplierFromScoreComponentOnCalculation}";
        if (modeComponent.didPlayerLoseBall) { modeFinishMultiplyCounter.text = ""; }
        yield return new WaitForSecondsRealtime(2f);

        timeSubtract = modeComponent.timescaleBonus * 10;

        if (modeComponent.didPlayerLoseBall)
        {
            timeSubtract = 0;
        }

        while (timeSubtract > 0)
        {
            if (confirmButton.lfIsHeld || confirmButton.rfIsHeld)
            {
                timeSubtract = 0;
                break;
            }
            timeSubtract = timeSubtract - 500;
            modeFinishSpeedCounter.text = $"{timeSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            resultsCountdownPlayback();
            yield return new WaitForSecondsRealtime(0.0001f);
        }

        if (timeSubtract <= 0)
        {
            timeSubtract = 0;
            modeFinishSpeedCounter.text = $"{timeSubtract}";
        }

        ballSubtract = (scoreComponent.ballsLeft * 100);

        if (modeComponent.didPlayerLoseBall)
        {
            ballSubtract = 0;
        }

        while (ballSubtract > 0)
        {
            if (confirmButton.lfIsHeld || confirmButton.rfIsHeld)
            {
                ballSubtract = 0;
                break;
            }
            ballSubtract = ballSubtract - 100;
            modeFinishBallCounter.text = $"{ballSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            resultsCountdownPlayback();
            yield return new WaitForSecondsRealtime(0.0001f);
        }

        secondSubtract = modeComponent.secondsUntilModeEnds * modeComponent.multiplierFromScoreComponentOnCalculation * 100;

        if (modeComponent.didPlayerLoseBall)
        {
            secondSubtract = 0;
        }

        while (secondSubtract > 0)
        {
            if (confirmButton.lfIsHeld || confirmButton.rfIsHeld)
            {
                secondSubtract = 0;
                break;
            }
            secondSubtract = secondSubtract - 500;
            modeFinishTimeCounter.text = $"{secondSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            resultsCountdownPlayback();
            yield return new WaitForSecondsRealtime(0.0001f);
        }

        if (secondSubtract <= 0)
        {
            secondSubtract = 0;
            modeFinishTimeCounter.text = $"{secondSubtract}";
        }

        while (scoreDisplay < scoreComponent.pl_score)
        {
            if(confirmButton.lfIsHeld || confirmButton.rfIsHeld)
            {
                scoreDisplay = scoreComponent.pl_score;
                break; //Breaks out of the loop if the player doesn't want to wait for the score to go all the way up on-screen.
            }
            scoreDisplay = scoreDisplay + 256;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            resultsCountdownPlayback();
            yield return new WaitForSecondsRealtime(0.000001f);
        }

        modeFinishFinalScoreCounter.text = $"{scoreComponent.pl_score}";
        modeFinishSpeedCounter.text = $"0";
        modeFinishBallCounter.text = $"0";
        modeFinishTimeCounter.text = $"0";
        audioManager.SE_resultsCashRegister.Play();

        if(modeComponent.multiplierFromScoreComponentOnCalculation == 8)
        {
            yield return new WaitForSecondsRealtime(1.5f);
            audioManager.jingle_winExtra.Play();
            specialMessage.text = "EXTRA BALL GET!!";
        }

        yield return new WaitForSecondsRealtime(1f);
        canShowScore = true;
        audioManager.stageBGM.Play();
        yield return null;
    }

    void resultsCountdownPlayback() //so i dont have to constantly do this if statement in the coroutine multiple times.
    {
        if (audioManager.SE_resultsCountdown.isPlaying == false)
        {
            audioManager.SE_resultsCountdown.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canShowScore)
        {
            if (confirmButton.rfIsHeld || confirmButton.lfIsHeld)
            {
                modeComponent.revertModeToNormal(); //The game mode state goes back to Normal, clears all the UI text strings.
                modeFinishSpeedCounter.text = $"";
                modeFinishBallCounter.text = $"";
                modeFinishTimeCounter.text = $"";
                modeFinishMultiplyCounter.text = $"";
                specialMessage.text = "";
                finishTitle.text = "FINISH!!";
                scoreDisplay = scoreComponent.pl_score;
                canShowScore = false;
                modeFinishInterruptEvent.SetActive(false);
            }
        }


    }


}
