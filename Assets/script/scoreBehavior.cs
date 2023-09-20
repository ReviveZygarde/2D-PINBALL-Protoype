using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBehavior : MonoBehaviour
{
    private ModeBehavior modeBehavior;
    public int ballsLeft = 3;
    public int pl_score;
    public enum multiplier
    { X1, X2, X4, X6, X8, X10 }
    public multiplier multiplierState = multiplier.X1;

    // Start is called before the first frame update
    void Start()
    {
        pl_score = 0;
        modeBehavior = GetComponent<ModeBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
