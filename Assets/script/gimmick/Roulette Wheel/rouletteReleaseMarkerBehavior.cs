using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteReleaseMarkerBehavior : MonoBehaviour
{
    public bool isOKtoRelease;
    public RouletteManager rouletteManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Pinball")
        {
            if(rouletteManager.waitBuffer >= rouletteManager.WaitBufferGoal)
            {
                isOKtoRelease = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
