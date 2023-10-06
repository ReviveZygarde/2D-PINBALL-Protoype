using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballCounterForUI : MonoBehaviour
{
    public scoreBehavior scoreBehaviorFromCommon;
    public Text ballAmountInUI;

    // Update is called once per frame
    void Update()
    {
        ballAmountInUI.text = $"{scoreBehaviorFromCommon.ballsLeft}";
    }
}
