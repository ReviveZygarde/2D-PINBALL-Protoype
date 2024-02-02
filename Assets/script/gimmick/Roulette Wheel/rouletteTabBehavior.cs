using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rouletteTabBehavior : MonoBehaviour
{
    [SerializeField] private int numberValue;
    [SerializeField] private ModeBehavior modeComponent;
    private int pointsToAdd;
    public scoreBehavior scoreBehavior;
    public GameObject Pinball;
    public bool canContactPinball = true;
    public bool canHoldOntoPinball;
    private Collider2D triggerCollider;
    public RouletteManager rouletteManager;
    [SerializeField] private GameObject childParticleObject;
    public Text UIstatusText;
    public TextMeshPro numberMonitorText;

    // Start is called before the first frame update
    void Start()
    {
        scoreBehavior = GameObject.Find("common").GetComponent<scoreBehavior>();
        modeComponent = GameObject.Find("common").GetComponent<ModeBehavior>();
        Pinball = GameObject.Find("Pinball");
        triggerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Pinball)
        {
            if (canContactPinball)
            {
                childParticleObject.SetActive(false);
                childParticleObject.SetActive(true);
                numberMonitorText.text = numberValue.ToString();
                applyBonusPoints();
                //Code that makes the ball move with the trigger goes here.
                canHoldOntoPinball = true;
                rouletteManager.initiateCoroutine();
                //Code that releases the ball goes here. Make a coroutine on a timer so the ball doesnt get constantly stuck on the wheel.
            }
        }
    }

    void applyBonusPoints()
    {
        //simply have the value multiply by the multiplier, add it to the score.
        //if the value is 0, do not do anything.
            if (numberValue > 0)
            {
                switch (scoreBehavior.multiplierState)
                {
                    case scoreBehavior.multiplier.X1:
                        if (scoreBehavior.multiplierState == scoreBehavior.multiplier.X1)
                        {
                            pointsToAdd = numberValue * 1;
                        }
                        break;
                    case scoreBehavior.multiplier.X2:
                        if (scoreBehavior.multiplierState == scoreBehavior.multiplier.X2)
                        {
                            pointsToAdd = numberValue * 2;
                        }
                        break;
                    case scoreBehavior.multiplier.X4:
                        if (scoreBehavior.multiplierState == scoreBehavior.multiplier.X4)
                        {
                            pointsToAdd = numberValue * 4;
                        }
                        break;
                    case scoreBehavior.multiplier.X6:
                        if (scoreBehavior.multiplierState == scoreBehavior.multiplier.X6)
                        {
                            pointsToAdd = numberValue * 6;
                        }
                        break;
                    case scoreBehavior.multiplier.X8:
                        if (scoreBehavior.multiplierState == scoreBehavior.multiplier.X8)
                        {
                            pointsToAdd = numberValue * 8;
                        }
                        break;
                    case scoreBehavior.multiplier.X10:
                        if (scoreBehavior.multiplierState == scoreBehavior.multiplier.X10)
                        {
                            pointsToAdd = numberValue * 10;
                        }
                        break;
                }
            scoreBehavior.pl_score = scoreBehavior.pl_score + pointsToAdd;
            UIstatusText.text = $"JACKPOT! {pointsToAdd} POINTS!";
            if(modeComponent.modeState == ModeBehavior.currentMode.RUSH || modeComponent.modeState == ModeBehavior.currentMode.BOSS)
            {
                modeComponent.secondsUntilModeEnds += numberValue;
                UIstatusText.text = $"TIME EXTENSION! {numberValue} SEC.";
            }
        }
        else
        {
            UIstatusText.text = "A DUD...";
        }
    }

    public void reEnableCollider()
    {
        canContactPinball = true;
        triggerCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canHoldOntoPinball)
        {
            Pinball.transform.position = this.transform.position;
        }
        if(canContactPinball == false)
        {
            triggerCollider.enabled = false;
        }
    }
}
