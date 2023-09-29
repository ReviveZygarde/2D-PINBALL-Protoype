using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class pointsTallyForUI : MonoBehaviour
{
    public Text pointsCounter;
    public scoreBehavior ScoreBehavior;

    // Update is called once per frame
    void Update()
    {
        pointsCounter.text = $"{ScoreBehavior.pl_score}";
    }
}
