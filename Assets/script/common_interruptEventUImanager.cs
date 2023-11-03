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
    private Text modeFinishSpeedCounter;
    private Text modeFinishBallCounter;
    private Text modeFinishTimeCounter;
    private Text modeFinishMultiplyCounter;
    private Text modeFinishFinalScoreCounter;
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
        modeFinishSpeedCounter.text = $"{(int)(Time.timeScale * 10)}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishBallCounter.text = $"{(scoreComponent.ballsLeft * 100)}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishTimeCounter.text = $"{modeComponent.secondsUntilModeEnds}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishMultiplyCounter.text = $"{scoreComponent.multiplierState}";
        yield return new WaitForSecondsRealtime(2f);
        canShowScore = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShowScore)
        {
            timeSubtract = (int)(Time.timeScale * 10);
            if (timeSubtract > 0)
            {
                timeSubtract--;
                modeFinishSpeedCounter.text = $"{timeSubtract}";
            }

            ballSubtract = (scoreComponent.ballsLeft * 100);
            if(ballSubtract > 0)
            {
                ballSubtract--;
            }
            secondSubtract = modeComponent.secondsUntilModeEnds;
            if(secondSubtract > 0)
            {
                secondSubtract--;
            }
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            canShowScore = false;
        }
        if (confirmButton.rfIsHeld)
        {
            modeComponent.revertModeToNormal(); //The game mode state goes back to Normal.
        }

    }


}
