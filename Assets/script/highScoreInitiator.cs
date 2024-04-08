using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoreInitiator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        globalScorekeep.Instance.compareScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
