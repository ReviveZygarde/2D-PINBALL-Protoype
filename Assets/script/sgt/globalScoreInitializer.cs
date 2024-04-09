using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalScoreInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        globalScoreBehavior.Instance.global_pl_score = 0;
    }
}
