using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = $"{globalScoreBehavior.Instance.global_pl_score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
