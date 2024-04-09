using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class globalScorekeep : Singleton<globalScorekeep>
{
    private globalScoreBehavior gl_score;
    public int placeBeaten;
    public bool hasReachedHighScore;
    public List<string> names;
    public List<int> scores;

    private void Start()
    {
        gl_score = globalScoreBehavior.Instance.GetComponent<globalScoreBehavior>();
    }

    public void compareScores()
    {
        int currentSpot = 0;

        foreach(int score in scores)
        {
            if (currentSpot > 7)
            {
                hasReachedHighScore = false;
                break;
            }
            if (gl_score.global_pl_score > scores[currentSpot])
            {
                //scores.Add(gl_score.global_pl_score);
                placeBeaten = currentSpot;
                scores.Insert(placeBeaten, gl_score.global_pl_score);
                hasReachedHighScore = true;
                break;
            }
            currentSpot++;
        }
        //Sorts the list, then reverses it to show index 0 at the top, then the 8th place at the bottom
        //EDIT: never mind, how come I didnt see scores.Insert()? lol.
        //scores.Sort();
        //scores.Reverse();
    }
}
