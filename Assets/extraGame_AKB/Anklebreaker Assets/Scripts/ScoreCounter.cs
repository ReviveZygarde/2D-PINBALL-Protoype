using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private GameManager GM;
    public TextMeshProUGUI uiScoreCounterP1;
    public TextMeshProUGUI uiScoreCounterP2;

    private GameObject score_p1;
    private GameObject score_p2;

    // Start is called before the first frame update
    void Start()
    {
        score_p1 = GameObject.FindWithTag("ScoreP1");
        score_p2 = GameObject.FindWithTag("ScoreP2");

        //basketballHandler = GameObject.Find("Basketball Model").GetComponent<BasketballHandler>();
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiScoreCounterP1 = score_p1.GetComponent<TextMeshProUGUI>();
        //uiScoreCounterP2 = score_p2.GetComponent<TextMeshProUGUI>();
        if(score_p2 != null)
        {
            uiScoreCounterP2 = score_p2.GetComponent<TextMeshProUGUI>();
        }
    }

    
    void FixedUpdate()
    {

        //Update UI
        uiScoreCounterP1.text = GM.scoreP1.ToString();
        if(score_p2 != null)
        {
            uiScoreCounterP2.text = GM.scoreP2.ToString();
        }

    }
}
