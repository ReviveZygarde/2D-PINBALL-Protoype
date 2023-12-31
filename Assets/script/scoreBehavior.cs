using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBehavior : MonoBehaviour
{
    private ModeBehavior modeBehavior;
    private globalScoreBehavior gl_scoreBehavior;
    public int ballsLeft = 3;
    public int pl_score;
    public enum multiplier
    { X1, X2, X4, X6, X8, X10 }
    public multiplier multiplierState = multiplier.X1;

    // Start is called before the first frame update
    void Start()
    {
        gl_scoreBehavior = GameObject.Find("GL_score").GetComponent<globalScoreBehavior>();
        pl_score = gl_scoreBehavior.global_pl_score;
        modeBehavior = GetComponent<ModeBehavior>();
    }

    public void applyScoreToGLscore()
    {
        gl_scoreBehavior.global_pl_score = pl_score;
    }

    // Update is called once per frame
    void Update()
    {
        applyScoreToGLscore();
    }
}
