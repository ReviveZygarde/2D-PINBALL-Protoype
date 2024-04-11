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

    public void compareScores() //simply compares the int of globalScoreBehavior with those in the Scores list here.
    {
        int currentSpot = 0;

        foreach(int score in scores)
        {
            if (currentSpot > 7)
            {
                hasReachedHighScore = false;
                break;
            }
            if (gl_score.global_pl_score >= scores[currentSpot])
            {
                //scores.Add(gl_score.global_pl_score);
                placeBeaten = currentSpot;
                scores.Insert(placeBeaten, gl_score.global_pl_score); //insert the score at the place it beat.
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

    public void truncateNamesAndScoresList()
    {
        //This is to conserve memory and prevent the
        //memory/RAM filling up if the game is playing
        //for a REALLY long time. So what this does is
        //simply removing the name and score that is at
        //the very last place (so technically a hidden
        //"9th" place that isn't shown to the player)
        if (names.Count > 8 && scores.Count > 8)
        {
            names.RemoveAt(names.Count - 1);
            scores.RemoveAt(scores.Count - 1);
        }
    }
}
