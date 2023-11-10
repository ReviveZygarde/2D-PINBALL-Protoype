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

    //This is to properly restart the UI position transforms and all that stuff to its initial values if possible.
    public GameObject modeFinishInterruptEvent;
    public Text modeFinishSpeedCounter;
    public Text modeFinishBallCounter;
    public Text modeFinishTimeCounter;
    public Text modeFinishMultiplyCounter;
    public Text modeFinishFinalScoreCounter;
    private int scoreDisplay;
    private bool canShowScore;

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
    }

    public void resetBossInterruptBars()
    {
        GameObject tmp_UIbottomBars = GameObject.Find("int_b_barsBottom");
        GameObject tmp_UItopBars = GameObject.Find("int_b_barsTop");
        tmp_UIbottomBars.transform.localPosition = Vector2.zero;
        tmp_UItopBars.transform.localPosition = Vector2.zero;
    }

    public void screenAfterCalculate()
    {
        modeFinishInterruptEvent.SetActive(true);
        StartCoroutine(showModeEndStats());
    }

    IEnumerator showModeEndStats()
    {
        canShowScore = false;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishSpeedCounter.text = $"{modeComponent.timescaleBonus * 10}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishBallCounter.text = $"{(scoreComponent.ballsLeft * 100)}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishTimeCounter.text = $"{modeComponent.secondsUntilModeEnds * modeComponent.multiplierFromScoreComponentOnCalculation * 100}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishMultiplyCounter.text = $"{scoreComponent.multiplierState}";
        yield return new WaitForSecondsRealtime(2f);

        timeSubtract = modeComponent.timescaleBonus * 10;
        while (timeSubtract > 0)
        {
            timeSubtract--;
            modeFinishSpeedCounter.text = $"{timeSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.0001f);
        }

        ballSubtract = (scoreComponent.ballsLeft * 100);
        while (ballSubtract > 0)
        {
            ballSubtract--;
            modeFinishBallCounter.text = $"{ballSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.0001f);
        }

        secondSubtract = modeComponent.secondsUntilModeEnds * modeComponent.multiplierFromScoreComponentOnCalculation * 100;
        while (secondSubtract > 0)
        {
            secondSubtract--;
            modeFinishTimeCounter.text = $"{secondSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.0001f);
        }

        while(scoreDisplay < scoreComponent.pl_score)
        {
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.000001f);
            if(confirmButton.lfIsHeld || confirmButton.rfIsHeld) //so the player doesnt have to wait
            {
                scoreDisplay = scoreComponent.pl_score;
                modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            }
        }
        canShowScore = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShowScore)
        {
            if (confirmButton.rfIsHeld || confirmButton.lfIsHeld)
            {
                modeComponent.revertModeToNormal(); //The game mode state goes back to Normal.
                modeFinishSpeedCounter.text = $"";
                modeFinishBallCounter.text = $"";
                modeFinishTimeCounter.text = $"";
                modeFinishMultiplyCounter.text = $"";
                canShowScore = false;
                modeFinishInterruptEvent.SetActive(false);
            }
        }


    }


}
