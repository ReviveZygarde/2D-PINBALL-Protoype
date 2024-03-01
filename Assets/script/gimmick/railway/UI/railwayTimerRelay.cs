using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class railwayTimerRelay : MonoBehaviour
{
    [SerializeField] private railwayManager rManager;
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = rManager.timeLeft.ToString();
    }
}
