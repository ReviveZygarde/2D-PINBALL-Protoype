using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteTabBehavior : MonoBehaviour
{
    [SerializeField] private int numberValue;
    private int pointsToAdd;
    public scoreBehavior scoreBehavior;

    // Start is called before the first frame update
    void Start()
    {
        scoreBehavior = GameObject.Find("common").GetComponent<scoreBehavior>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pinball")
        {
            //Code that makes the ball move with the trigger goes here.
            applyBonusPoints();
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
                    if(scoreBehavior.multiplierState == scoreBehavior.multiplier.X1)
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
