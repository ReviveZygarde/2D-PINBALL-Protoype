using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railwayPauseResume : MonoBehaviour
{
    private GameObject Pinball;
    public bool doesPauseTimer;
    private railwayManager railwayManager;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        railwayManager = GameObject.Find("railway").GetComponent<railwayManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Pinball)
        {
            if (doesPauseTimer)
            {
                railwayManager.pauseTimer();
            }
            else
            {
                railwayManager.pauseTimer();
                railwayManager.resumeTimer();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
