using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneByScore : MonoBehaviour
{
    private scoreDisplay scoreDisplaySceneParam;
    // Start is called before the first frame update
    void Start()
    {
        globalScorekeep.Instance.compareScores();
        scoreDisplaySceneParam = GetComponent<scoreDisplay>();
        changeScene();
    }

    void changeScene() //if the globalScorekeep has the high score beaten bool, it simply changes the string the other script (scoreDisplay) references.
    {
        if(globalScorekeep.Instance.hasReachedHighScore)
        {
            scoreDisplaySceneParam.jumpToScene = "highScoreMenu";
        }
    }
}
