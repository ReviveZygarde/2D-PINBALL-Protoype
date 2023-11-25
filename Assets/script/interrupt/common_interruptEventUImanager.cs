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

    public void resetBossInterruptBars()
    {
        //Finds UI game objects, and resets their localPosition to zero.
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
        //This basically relays all the variable data on-screen.
        canShowScore = false;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishSpeedCounter.text = $"{modeComponent.timescaleBonus * 10}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishBallCounter.text = $"{(scoreComponent.ballsLeft * 100)}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishTimeCounter.text = $"{modeComponent.secondsUntilModeEnds * modeComponent.multiplierFromScoreComponentOnCalculation * 100}";
        yield return new WaitForSecondsRealtime(0.5f);
        modeFinishMultiplyCounter.text = $"{modeComponent.multiplierFromScoreComponentOnCalculation}";
        yield return new WaitForSecondsRealtime(2f);

        timeSubtract = modeComponent.timescaleBonus * 10;
        while (timeSubtract > 0)
        {
            timeSubtract--;
            modeFinishSpeedCounter.text = $"{timeSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.0001f);
            if(timeSubtract <= 0)
            {
                timeSubtract = 0;
            }
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
            secondSubtract = secondSubtract - 150;
            modeFinishTimeCounter.text = $"{secondSubtract}";
            scoreDisplay++;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.0001f);
            if(secondSubtract <= 0)
            {
                secondSubtract = 0;
            }
        }

        while(scoreDisplay < scoreComponent.pl_score)
        {
            scoreDisplay = scoreDisplay + 256;
            modeFinishFinalScoreCounter.text = $"{scoreDisplay}";
            yield return new WaitForSecondsRealtime(0.000001f);
        }
        modeFinishFinalScoreCounter.text = $"{scoreComponent.pl_score}";
        if(modeComponent.multiplierFromScoreComponentOnCalculation == 8)
        {
            audioManager.jingle_winExtra.Play();
            specialMessage.text = "EXTRA BALL GET!!";
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
                modeComponent.revertModeToNormal(); //The game mode state goes back to Normal, clears all the UI text strings.
                modeFinishSpeedCounter.text = $"";
                modeFinishBallCounter.text = $"";
                modeFinishTimeCounter.text = $"";
                modeFinishMultiplyCounter.text = $"";
                specialMessage.text = "";
                scoreDisplay = scoreComponent.pl_score;
                canShowScore = false;
                modeFinishInterruptEvent.SetActive(false);
            }
        }


    }


}
