using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class leaderboardVisualBehavior : MonoBehaviour
{
    private globalScorekeep leaderboard;
    [SerializeField] private TextMeshProUGUI[] displayNames;
    [SerializeField] private TextMeshProUGUI[] displayScores;

    // Start is called before the first frame update
    void Start()
    {
        leaderboard = globalScorekeep.Instance.GetComponent<globalScorekeep>();
        for(int i = 0; i < displayNames.Length; i++)
        {
            displayNames[i].text = leaderboard.names[i];
        }
        for (int i = 0; i < displayScores.Length; i++)
        {
            displayScores[i].text = leaderboard.scores[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
